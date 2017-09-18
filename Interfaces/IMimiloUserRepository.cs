using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Mimilo.Models;
using Mimilo.ViewModels;

namespace Mimilo.Interfaces
{
    public interface IMimiloUserRepository
    {
        MimiloUser GetUserByEmailAndPassword(LoginViewModel loginUser);

        Task<SignInResult> LogInUserByEmailAndPassword(LoginViewModel loginUser);

        List<MimiloUser> GetAllUsers();
    }
}