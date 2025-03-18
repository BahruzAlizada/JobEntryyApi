using JobEntryy.Application.DTOs;

namespace JobEntryy.Application.Abstracts
{
    public interface ITokenHandler
    {
        TokenDto CreateAccessToken(int minute);
        string CreateRefreshToken();
    }
}
