using BCX_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BCX_Api.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BCXContext _context;

        public AccountRepository(BCXContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.DisposeAsync();
        }

        public async Task<User> LoginUser(string userName, string password)
        {
            var loggedMember = _context.Users.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
            return await loggedMember;
        }
    }
}