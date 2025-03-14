namespace JobEntryy.Application.Parametres.ResponseParametres
{
    public class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public static Result Create(bool success, string? message=null)
        {
            return new Result
            {
                Success = success,
                Message = message
            };
        }
    }
}
