using JobEntryy.Domain.Common;

namespace JobEntryy.Domain.Entities
{
    public class Experience : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Job> Jobs { get; set; }



        public static Experience Create(string name)
        {
            Experience experience = new Experience
            {
                Name = name
            };
            return experience;
        }
        public void Update(string newName)=> Name = newName;
    }
}
