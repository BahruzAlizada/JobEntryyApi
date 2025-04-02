

namespace JobEntryy.Application.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }
        public DateTime Created { get; set; }
        public string[] Roles { get; set; }
    }
}
