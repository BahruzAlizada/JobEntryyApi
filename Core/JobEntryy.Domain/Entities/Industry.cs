using JobEntryy.Domain.Common;

namespace JobEntryy.Domain.Entities
{
    public class Industry : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<CompanyIndustry> CompanyIndustries { get; set; }



        public static Industry Create(string name)
        {
            Industry industry = new Industry
            {
                Name = name
            };
            return industry;
        }

        public void Update(string newName) => Name = newName;
    }
}
