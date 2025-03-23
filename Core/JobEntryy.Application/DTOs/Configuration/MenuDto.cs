

namespace JobEntryy.Application.DTOs
{
    public class MenuDto
    {
        public string Name { get; set; }
        public List<ActionDto> Actions { get; set; } = new();
    }
}
