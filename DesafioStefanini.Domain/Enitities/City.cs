using System.Collections.Generic;

namespace DesafioStefanini.Domain.Enitities
{
    public class City : BaseEntity
    {
        public City()
        {

        }
        public string Name { get; set; }
        public string UF { get; set; }
        public Person Person { get; set; }
    }
}
