using JobEntryy.Application.DTOs;

namespace JobEntryy.Application.Abstracts
{
    public interface IApplicationService
    {
        List<MenuDto> GetAuthorizeDefinitionEndpoints(Type type);
    }
}
