using System.ComponentModel.DataAnnotations;

namespace DesafioStefanini.Application.DTOs
{
    public class CityDTO : BaseDTO
    {
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2)]
        public string UF { get; set; }
    }
}
