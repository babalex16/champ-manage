using ChampManage.API.Entities;

namespace ChampManage.API.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
