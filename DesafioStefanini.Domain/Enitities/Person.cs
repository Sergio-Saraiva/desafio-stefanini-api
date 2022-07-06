namespace DesafioStefanini.Domain.Enitities
{
    public class Person : BaseEntity
    {
        public Person()
        {

        }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int Age { get; set; }
        public City City { get; set; }
        public string CityId { get; set; }

    }
}
