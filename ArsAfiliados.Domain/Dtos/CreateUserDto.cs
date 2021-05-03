
using System.ComponentModel.DataAnnotations;

namespace ArsAfiliados.Domain.Dtos
{
    public class CreateUserDto : LogerDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
