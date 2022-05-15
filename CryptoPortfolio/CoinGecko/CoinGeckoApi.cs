using System.Net;
using System.Security.Cryptography.X509Certificates;
using CryptoPortfolio.Data;
using CryptoPortfolio.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CryptoPortfolio.CoinGecko;

public interface ICoinGeckoApi
{
    public double getLatestPrice(string CgId);
    public void CheckForNewCryptos();
    public void SaveBulk(List<CoinGeckoCoin> list);
}
public class CoinGeckoApi : ICoinGeckoApi
{
    private readonly CryptoPortfolioContext _cryptoPortfolioContext;
    private static Uri BASEURI = new Uri("https://api.coingecko.com/api/v3/");
    private static DateTime lastChecked = DateTime.MinValue;

    public CoinGeckoApi(CryptoPortfolioContext cryptoPortfolioContext)
    {
        _cryptoPortfolioContext = cryptoPortfolioContext;
    }

    public double getLatestPrice(string cryptoName)
    {
        return 5.0;
    }

    public void CheckForNewCryptos()
    {
        if (DateTime.Now - lastChecked > TimeSpan.FromHours(0.5)) //don't refresh data if latest update was 30 min ago
        {
            List<CoinGeckoCoin> latestAvailableCoins = this.GetLatestAvailableCoins();

            if (latestAvailableCoins.Count > _cryptoPortfolioContext.CoinGeckoCoin.Count())
            {
                SaveBulk(latestAvailableCoins);
            }
            //update last checked
            lastChecked = DateTime.Now;
        }
        
    }

    //als nieuw: save, oude blijven ongewijzigd
    public void SaveBulk(List<CoinGeckoCoin> list)
    {
        //split given list into 2 lists: coins that need to be updated, and coins that need to be added
        List<CoinGeckoCoin> dbList = _cryptoPortfolioContext.CoinGeckoCoin.Where(x => x.CoinGeckoId != null).ToList();
        List<CoinGeckoCoin> saveList = list.Where(x => !dbList.Exists(y => y.CoinGeckoId == x.CoinGeckoId)).ToList();
       
        //oude code om update updates van uit CG op te slaan in db maar is niet nodig
        // List<CoinGeckoCoin> updateList = new List<CoinGeckoCoin>();

        // foreach (CoinGeckoCoin coin in list)
        // {
        //     CoinGeckoCoin temp = dbList.FirstOrDefault(x => x.CoinGeckoId == coin.CoinGeckoId);
        //     if (temp != null)
        //     {
        //         updateList.Add(temp);
        //     }
        // }


        // _cryptoPortfolioContext.CoinGeckoCoin.UpdateRange(updateList);
        _cryptoPortfolioContext.CoinGeckoCoin.AddRange(saveList);
        _cryptoPortfolioContext.SaveChanges();
    }

    /// <summary>
    /// get the latest available coins and coin IDs from the coingecko API
    /// </summary>
    /// <returns>List&lt;CoinGeckoCoin&gt;</returns>
    /// <exception cref="HttpRequestException"></exception>
    public List<CoinGeckoCoin> GetLatestAvailableCoins()
    {
        
        List<CoinGeckoCoin> list = new List<CoinGeckoCoin>();
        HttpClient client = new HttpClient();
        try
        {
            client.BaseAddress = BASEURI;
            var response = client.GetAsync(@"coins/list").Result;
            
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    "Something went wrong while trying to get the latest coins from CoinGecko",null,response.StatusCode);
            }

            string stringContent = response.Content.ReadAsStringAsync().Result;
            
            List<CoinGeckoCoinJson> coinList = JsonConvert.DeserializeObject<List<CoinGeckoCoinJson>>(stringContent);
            
            if (coinList.Count == 0) 
                throw new HttpRequestException("no coins recieved from CG", null, HttpStatusCode.Conflict);
            
            foreach (CoinGeckoCoinJson coin in coinList)
            {
                CoinGeckoCoin temp = new CoinGeckoCoin
                {
                    Id = 0,
                    CoinGeckoId = coin.id,
                    Symbol = coin.symbol,
                    CoinGeckoName = coin.name
                };
                list.Add(temp);
            }
            lastChecked = DateTime.Now;
            return list;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    
}