
namespace JobEntryy.Application.Parametres.ResponseParametres
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message)
        {
            Success = true;
            Message = message;
        }

        public static Result Create(string message)
        {
            return new SuccessResult(message);
        }

        internal static Result Create(object messsages)
        {
            throw new NotImplementedException();
        }
    }
}
