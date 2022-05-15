using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CryptoPortfolio.Models.Enum;
using Microsoft.VisualBasic;

namespace CryptoPortfolio.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(10)]
        [Display(Name = "Ticker")]
        public string ShortName { get; set; }

        [Display(Name = "Crypto Name")]
        public string CryptoName { get; set; }
        
        [ForeignKey("CoinGeckoCoin")]
        public int? CoinGeckoCoinId { get; set; }
        public double CryptoAmount { get; set; }
        public double FiatAmount { get; set; }

        [DisplayName("Fiat")]
        //[DataType(DataType.Currency)]
        [ForeignKey("FiatType")]
        public int FiatTypeId { get; set; }
        public TransactionType TransactionType { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy:-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
        
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy:-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ModifiedOn { get; set; }
        
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy:-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeletedOn { get; set; }
    }
}
