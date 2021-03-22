using BCX_Api.Models;
using System;
using System.Threading.Tasks;

namespace BCX_Api.Repositories
{
    public interface IAccountRepository : IDisposable
    {
        Task<User> LoginUser(string userName, string password);
    }
}