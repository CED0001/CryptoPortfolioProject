using CryptoPortfolio.CoinGecko;
using CryptoPortfolio.Models;
using CryptoPortfolio.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace CryptoPortfolio.Data
{
    public class Seeder
    {
        internal static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new CryptoPortfolioContext(serviceProvider.GetRequiredService<DbContextOptions<CryptoPortfolioContext>>());
            context.Database.EnsureCreated();
            if (!context.Transaction.Any())
            {
                context.Transaction.AddRange
                (new Transaction
                {
                    CoinGeckoCoinId = null,
                    CreatedOn = DateTime.Now,
                    CryptoAmount = 0.0015,
                    CryptoName = "Bitcoin",
                    DeletedOn = DateTime.MaxValue,
                    FiatAmount = 500,
                    FiatTypeId = 26,
                    ShortName = "btc",
                    TransactionType = TransactionType.buy
                },
                new Transaction
                {
                    CoinGeckoCoinId = null,
                    CreatedOn = DateTime.Now,
                    CryptoAmount = 0.01,
                    CryptoName = "Ethereum",
                    DeletedOn = DateTime.MaxValue,
                    FiatAmount = 500,
                    FiatTypeId = 26,
                    ShortName = "eth",
                    TransactionType = TransactionType.buy
                });
                
                context.SaveChanges();
            }

        }

       
    }
}
