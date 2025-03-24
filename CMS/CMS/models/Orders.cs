using System.ComponentModel.DataAnnotations;

namespace CMS.models
{
    public class Orders
    {
        [Key]
        public int orderId { get; set; }
        public int CustId { get; set; }
        public int MenuId { get; set; }
        public int VendorId { get; set; }
        public int QtyOrd { get; set; }
        public decimal BillAmount { get; set; }
        public string OrderStatus { get; set; } = "PENDING";
        public string OrderComments { get; set; }
    }
}
