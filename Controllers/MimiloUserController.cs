using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mimilo.Interfaces;
using Mimilo.Models;

namespace Mimilo.Controllers
{
    [Route("api/[controller]")]
    public class MimiloUserController
    {
        private IMimiloUserRepository _mimiloUserRepository;

        public MimiloUserController(IMimiloUserRepository mimiloUserRepository)
        {
            _mimiloUserRepository = mimiloUserRepository;
        }

        [HttpGet("GetUserByEmailAndPassword")]
        public MimiloUser GetUserByEmailAndPassword(string email, string password)
        {
            return _mimiloUserRepository.GetUserByEmailAndPassword(email, password);
        }

        [HttpGet("GetAllUsers")]
        public List<MimiloUser> GetAllUsers()
        {
            return _mimiloUserRepository.GetAllUsers();
        }
    }
}