namespace JobEntryy.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Status { get; set; } = true;


        public void ToogleStatus()=> Status = !Status;
        public void ToogleActivited() => Status = true;
        public void ToogleDeactivited()=> Status = false;
    }
}
