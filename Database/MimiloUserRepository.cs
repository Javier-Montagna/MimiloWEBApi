using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mimilo.Interfaces;
using Mimilo.Models;
using Mimilo.ViewModels;

namespace Mimilo.Database
{
    public class MimiloUserRepository : IMimiloUserRepository
    {
        private MimiloContext _context;
        private readonly RoleManager<MimiloRole> _roleManager;
        private readonly UserManager<MimiloUser> _userManager;
        private readonly SignInManager<MimiloUser> _signinManager;

        public MimiloUserRepository(MimiloContext context, UserManager<MimiloUser> userManager,
            RoleManager<MimiloRole> roleManager, SignInManager<MimiloUser> signinManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signinManager;
        }

        public List<MimiloUser> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public async Task<SignInResult> LogInUserByEmailAndPassword(LoginViewModel loginUser)
        {
            return await _signinManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);
        }

        public MimiloUser GetUserByEmailAndPassword(LoginViewModel loginUser)
        {
            return _context.Users.Where(x => x.Email == loginUser.Email)
                .Include(y => y.ShoppingCart)
                .ThenInclude(z => z.LineItems)
                .ThenInclude(x => x.Product)
                .FirstOrDefault();
        }
    }
}