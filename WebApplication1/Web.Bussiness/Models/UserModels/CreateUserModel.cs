using System.ComponentModel.DataAnnotations;

namespace Web.Bussiness.Models.UserModels
{
    public class CreateUserModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}