using System.ComponentModel.DataAnnotations;

namespace MOM_Project.Models
{
    public class UserModel
    {
        public int UserID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string MobileNo { get; set; }
    }
}
