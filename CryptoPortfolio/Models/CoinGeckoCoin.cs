using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoPortfolio.Models
{
    public class CoinGeckoCoin
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string? CoinGeckoId { get; set; }
        public string? Symbol { get; set; }
        public string? CoinGeckoName { get; set; }
    }
}
