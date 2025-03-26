using JobEntryy.Application.Constants;
using JobEntryy.Application.Parametres.ResponseParametres;
using JobEntryy.Application.Rules.Abstract;
using JobEntryy.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace JobEntryy.Application.Rules.Concrete
{
    public class RoleRuleService : IRoleRuleService
    {
        private readonly RoleManager<AppRole> roleManager;
        public RoleRuleService(RoleManager<AppRole> roleManager)
        {
            this.roleManager = roleManager;
        }



        public Result CheckNameIfExisted(string name, Guid? id = null)
        {
            if (id == null)
            {
                bool roleExist = roleManager.Roles.ToList().Any(x => x.Name == name);
                if(roleExist) return ErrorResult.Create(Messages.CheckIfNameExisted);
            }
            else
            {
                bool roleExist = roleManager.Roles.ToList().Any(x => x.Name == name && x.Id != id);
                if (roleExist) return ErrorResult.Create(Messages.CheckIfNameExisted);
            }

            return Result.Create(true);
        }
    }
}
