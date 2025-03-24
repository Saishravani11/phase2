using System.ComponentModel.DataAnnotations;

namespace CMS.models
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }

        public string? VendorName { get; set; }

        public string? VendorUserName { get; set; }

        public string? VendorEmail { get; set; }

        public string? VendorMobile { get; set; }


    }
}
