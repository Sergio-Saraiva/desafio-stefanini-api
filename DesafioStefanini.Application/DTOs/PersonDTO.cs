using System.ComponentModel.DataAnnotations;


namespace DesafioStefanini.Application.DTOs
{
    public class PersonDTO : BaseDTO
    {
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }


        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public CityDTO City { get; set; }

        public string CityId { get; set; }
    }
}
