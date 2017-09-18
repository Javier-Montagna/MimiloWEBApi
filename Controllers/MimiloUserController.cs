using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mimilo.Infrastructure;
using Mimilo.Interfaces;
using Mimilo.Models;
using Mimilo.ViewModels;
using System.Net.Http;
using System.Net;

namespace Mimilo.Controllers
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class MimiloUserController
    {
        private IMimiloUserRepository _mimiloUserRepository;

        public MimiloUserController(IMimiloUserRepository mimiloUserRepository)
        {
            _mimiloUserRepository = mimiloUserRepository;
        }

        [HttpPost("GetUserByEmailAndPassword")]
        public IActionResult GetUserByEmailAndPassword([FromBody] LoginViewModel loginUser)
        {
            var logInResult = _mimiloUserRepository.LogInUserByEmailAndPassword(loginUser);

            if (logInResult.Result.IsLockedOut)
            {
                return new BadRequestObjectResult("Usuario bloqueado");
            }

            if (logInResult.Result.Succeeded)
            {
                var user = _mimiloUserRepository.GetUserByEmailAndPassword(loginUser);
                return new OkObjectResult(user);
            }

            return new BadRequestObjectResult("Mail/Contraseña Invalidos");
        }

        [HttpGet("GetAllUsers")]
        public List<MimiloUser> GetAllUsers()
        {
            return _mimiloUserRepository.GetAllUsers();
        }
    }
}