
namespace JobEntryy.Application.Exceptions
{
    public class JobNotFoundException : Exception
    {
        public JobNotFoundException()
        {
        }

        public JobNotFoundException(string? message) : base(message)
        {
        }

        public JobNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}