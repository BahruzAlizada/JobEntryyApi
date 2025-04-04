﻿using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules.Abstract;

namespace JobEntryy.Application.Rules.Concrete
{
    public class CategoryRuleService : ICategoryRuleService
    {
        private readonly ICategoryReadRepository categoryReadRepository;
        public CategoryRuleService(ICategoryReadRepository categoryReadRepository)
        {
            this.categoryReadRepository = categoryReadRepository;
        }

        public Result CheckNameIfExist(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                var categoryExist = categoryReadRepository.GetAll().Any(x => x.Name == name && x.Id!=id);
                if (categoryExist) return ErrorResult.Create(Messages.CheckIfNameExisted);
            }
            else
            {
                var categoryExist = categoryReadRepository.GetAll().Any(x => x.Name == name);
                if (categoryExist) return ErrorResult.Create(Messages.CheckIfNameExisted);
            }

            return Result.Create(true);
        }
    }
}
