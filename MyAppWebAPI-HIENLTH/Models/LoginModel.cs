using System.ComponentModel.DataAnnotations;

namespace MyAppWebAPI_HIENLTH.Models
{
    public class LoginModel
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(250)]
        public string PassWord { get; set; }
    }
}
