using ChampManage.API.Entities;

namespace ChampManage.API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
