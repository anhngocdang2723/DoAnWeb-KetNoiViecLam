using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnWeb_KetNoiViecLam.Models
{
    [Table("ServiceInformation")]
    public class ServiceInformation
    {
        [Key]
        public int ServiceID { get; set; }

        [Display(Name = "Title")]
        public string? ServiceTitle { get; set; }

        [Display(Name = "Price")]
        public double? Price { get; set; }

        [Display(Name = "Category")]
        public string? Category { get; set; }

        [Display(Name = "English Level")]
        public string? EnglishLevel { get; set; }

        [Display(Name = "Response Time")]
        public string? ResponseTime { get; set; }

        [Display(Name = "Delivery Time")]
        public string? DeliveryTime { get; set; }

        [Display(Name = "Skills")]
        public string? Skills { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Display(Name = "Service Detail")]
        public string? ServiceDetail { get; set; }

        [Display(Name = "Status")]
        public string? Status { get; set; }
    }
}
