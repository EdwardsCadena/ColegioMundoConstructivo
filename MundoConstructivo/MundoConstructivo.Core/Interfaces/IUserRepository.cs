using MundoConstructivo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundoConstructivo.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetLoginByCredentials(UserLogin login);
        Task RegisterUser(User user);
    }
}
