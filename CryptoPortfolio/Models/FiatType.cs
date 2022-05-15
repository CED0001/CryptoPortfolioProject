using System.ComponentModel.DataAnnotations;

namespace CryptoPortfolio.Models
{
    public class FiatType
    {
        [Key]
        int Id { get; set; }
        
        [Required, MaxLength(10, ErrorMessage = "Max length for Abreviation is 10.")]
        private string Abreviation { get; set; }
    }
}
