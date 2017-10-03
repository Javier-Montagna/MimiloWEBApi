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
using Microsoft.Extensions.Logging;
using ajuaresCubi.Models;

namespace Mimilo.Controllers
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class MimiloUserController
    {
        private IMimiloUserRepository _mimiloUserRepository;
        private ILoggerFactory _loggerFactory;

        public MimiloUserController(IMimiloUserRepository mimiloUserRepository, ILoggerFactory loggerFactory)
        {
            _mimiloUserRepository = mimiloUserRepository;
            _loggerFactory = loggerFactory;
        }

        [HttpPost("GetUserByEmailAndPassword")]
        public IActionResult GetUserByEmailAndPassword([FromBody] LoginViewModel loginUser)
        {
            var logInResult = _mimiloUserRepository.LogInUserByEmailAndPassword(loginUser);

            if (logInResult.Result.IsLockedOut)
            {
                return new BadRequestObjectResult(new CustomError("Usuario bloqueado","GetUserByEmailAndPassword"));
            }

            if (logInResult.Result.Succeeded)
            {
                var user = _mimiloUserRepository.GetUserByEmailAndPassword(loginUser);
                return new OkObjectResult(user);
            }

            return new BadRequestObjectResult(new CustomError("Email/Contraseña Invalidos","GetUserByEmailAndPassword"));
        }

        [HttpGet("GetAllUsers")]
        public List<MimiloUser> GetAllUsers()
        {
            return _mimiloUserRepository.GetAllUsers();
        }
    }
}