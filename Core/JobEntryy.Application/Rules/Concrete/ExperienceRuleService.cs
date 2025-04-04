﻿using JobEntryy.Application.Abstracts.Services.EntityFramework;
using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules.Abstract;

namespace JobEntryy.Application.Rules.Concrete
{
    public class ExperienceRuleService : IExperienceRuleService
    {
        private readonly IExperienceReadRepository experienceReadRepository;
        public ExperienceRuleService(IExperienceReadRepository experienceReadRepository)
        {
            this.experienceReadRepository = experienceReadRepository;
        }


        public Result CheckNameIfExist(string name, Guid? id = null)
        {
            if (id.HasValue)
            {
                var experienceExist = experienceReadRepository.GetAll().Any(x => x.Name == name && x.Id != id);
                if (experienceExist) return ErrorResult.Create(Messages.CheckIfNameExisted);
            }
            else
            {
                var experienceExist = experienceReadRepository.GetAll().Any(x => x.Name == name);
                if (experienceExist) return ErrorResult.Create(Messages.CheckIfNameExisted);
            }

            return Result.Create(true);
        }
    }
}
