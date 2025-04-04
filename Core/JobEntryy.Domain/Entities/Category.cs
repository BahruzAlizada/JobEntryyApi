﻿using JobEntryy.Domain.Common;

namespace JobEntryy.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Job> Jobs { get; set; }


        public static Category Create(string name)
        {
            Category category = new Category
            {
                Name = name,
            };
            return category;
        }

        public void Update(string newName) => Name = newName;
    }
}
