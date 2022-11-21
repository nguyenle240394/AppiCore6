using DemoApiNet6.Data;

namespace DemoApiNet6.Domain
{
    public interface IUserRepository
    {
        Task<IEnumerable<SaUser>> GetAll();
        Task<Boolean> GetLogin(string userCode, string password);
        Task<SaUser> UpdateAsnyc(string userCode, SaUser user);
        Task<SaUser> GetUserByUserCode(string userCode);
        Task<SaUser> CreateUser(SaUser input);
    }
}
