using JobEntryy.Application.Parametres.ResponseParametres;

namespace JobEntryy.Application.Parametres.ResponseParametres
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message)
        {
            Success = false;
            Message = message;
        }

        public static Result Create(string message)
        {
            return new ErrorResult(message);
        }
    }
}

