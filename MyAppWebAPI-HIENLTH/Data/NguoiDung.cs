using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAppWebAPI_HIENLTH.Data
{
    [Table("NguoiDung")]
    public class NguoiDung
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(250)]
        public string PassWord { get; set; }

        public string HoTen { get; set; }
        public string Email { get; set; }
    }
}
