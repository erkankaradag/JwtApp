using System.ComponentModel.DataAnnotations;

namespace JwtApp.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
