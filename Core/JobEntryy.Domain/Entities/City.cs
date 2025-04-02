using JobEntryy.Domain.Common;

namespace JobEntryy.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Job> Jobs { get; set; }


        public static City Create(string name)
        {
            City city = new City
            {
                Name = name
            };
            return city;
        }
        public void Update(string newName) => Name = newName;
    }
} 
