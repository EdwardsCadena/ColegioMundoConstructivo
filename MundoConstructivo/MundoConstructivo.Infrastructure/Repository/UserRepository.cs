using Microsoft.EntityFrameworkCore;
using MundoConstructivo.Core.Entities;
using MundoConstructivo.Core.Interfaces;
using MundoConstructivo.Infrastructure.Data;
using MundoConstructivo.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundoConstructivo.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ColegioMundoConstructivoContext _context;
        protected readonly DbSet<User> _entities;
        private readonly IPasswordService _passwordService;

        public UserRepository(ColegioMundoConstructivoContext context, IPasswordService passwordService)
        {
            _context = context;
            _entities = context.Set<User>();
            _passwordService = passwordService;
        }

        public async Task<User> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Email == login.Email);
        }
        public async Task RegisterUser(User user)
        {
            DateTime currentDate = DateTime.Now;
            User registro = new User
            {
                Email = user.Email,
                Password = user.Password,
                DateCreation = currentDate,
            };
            _context.Users.Add(registro);
            await _context.SaveChangesAsync();
        }
    }
}