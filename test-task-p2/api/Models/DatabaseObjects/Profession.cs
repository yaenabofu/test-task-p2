using System.Collections.Generic;

namespace api.Models.DatabaseObjects
{
    public class Profession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Specialty> Specialties { get; set; }
    }
}
