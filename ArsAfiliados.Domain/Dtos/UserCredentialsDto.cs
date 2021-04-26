using System.ComponentModel.DataAnnotations;

namespace ArsAfiliados.Domain.Dtos
{
    public class UserCredentialsDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
