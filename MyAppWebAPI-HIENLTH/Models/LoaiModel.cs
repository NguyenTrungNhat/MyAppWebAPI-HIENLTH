using System.ComponentModel.DataAnnotations;

namespace MyAppWebAPI_HIENLTH.Models
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }
}
