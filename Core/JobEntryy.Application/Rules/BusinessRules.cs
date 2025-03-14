using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Rules
{
    public class BusinessRules
    {
        public static Result Run(params Result[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return Result.Create(true);
        }
    }
}
