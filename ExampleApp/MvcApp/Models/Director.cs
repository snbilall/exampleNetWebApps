using System.Collections.Generic;

namespace ExampleApp.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone{ get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
