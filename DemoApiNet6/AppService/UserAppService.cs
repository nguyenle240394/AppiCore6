using Azure.Core;
using DemoApiNet6.Data;
using DemoApiNet6.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoApiNet6.AppService
{
    public class UserAppService : IUserRepository
    {
        private readonly WmsClpDnTestContext _appDbContext;
        public UserAppService(WmsClpDnTestContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<SaUser> CreateUser(SaUser input)
        {
            var result = await _appDbContext.SaUsers.AddAsync(input);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<SaUser>> GetAll()
        {
            return await _appDbContext.SaUsers.ToListAsync();
        }

        public async Task<SaUser> GetUserByUserCode(string userCode)
        {
            var user = await _appDbContext.SaUsers.FirstOrDefaultAsync(x => x.UserCode == userCode);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<SaUser> UpdateAsnyc(string userCode, SaUser user)
        {
            Encryption encryption = new Encryption(); 
            var userIndatabase = await _appDbContext.SaUsers.FirstOrDefaultAsync(u => u.UserCode == userCode);
            if (userIndatabase != null)
            {
                userIndatabase.PasswordHash = encryption.Decrypt(user.PasswordHash);
                userIndatabase.EnterpriseCode = user.EnterpriseCode;
                userIndatabase.ModifiedDate = DateTime.Now;
                await _appDbContext.SaveChangesAsync();
                return userIndatabase;
            }
            return null;
        }

        async Task<bool> IUserRepository.GetLogin(string userCode, string password)
        {
            var user = await _appDbContext.SaUsers.FirstOrDefaultAsync(x => x.UserCode == userCode);
            if (user != null && user.PasswordHash == password)
            {
                return true;
            }
            return false;
        }
    }
}
