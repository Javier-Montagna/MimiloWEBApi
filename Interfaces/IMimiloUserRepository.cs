using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Mimilo.Models;

namespace Mimilo.Interfaces
{
    public interface IMimiloUserRepository
    {
        MimiloUser GetUserByEmailAndPassword(string email, string password);
        List<MimiloUser> GetAllUsers();
    }
}