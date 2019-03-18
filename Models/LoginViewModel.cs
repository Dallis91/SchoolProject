using System.ComponentModel.DataAnnotations;
namespace ticketApp.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [DisplayAttribute(Name="Email Adress")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string Password { get; set; }
    }
}