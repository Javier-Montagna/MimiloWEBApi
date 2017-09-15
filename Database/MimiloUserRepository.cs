using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Mimilo.Interfaces;
using Mimilo.Models;

namespace Mimilo.Database
{
    public class MimiloUserRepository : IMimiloUserRepository
    {
        private MimiloContext _context;

        public MimiloUserRepository(MimiloContext context)
        {
            _context = context;
        }

        public List<MimiloUser> GetAllUsers()
        {
            return _context.MimiloUsers.ToList();
        }

        public MimiloUser GetUserByEmailAndPassword(string email, string password)
        {
            return _context.MimiloUsers.Where(x=> x.Email == email && x.PasswordHash  == password).FirstOrDefault();
        }
    }
}