using System.ComponentModel.DataAnnotations;

namespace CMS.models
{
    public class Wallet
    {
        [Key]

        public int walletId { get; set; }

        public int? custId { get; set; }
        public string? walletType { get; set; }
        public decimal walletAmount { get; set; }
    }
}
