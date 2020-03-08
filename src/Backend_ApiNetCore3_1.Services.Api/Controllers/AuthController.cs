using Backend_ApiNetCore3_1.Application.Interfaces;
using KissLog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend_ApiNetCore3_1.Services.Api.Controllers
{
    [Route("[Controller]")]
    public class AuthController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly ILogger _logger;

        public AuthController(ITokenService tokenService, ILogger logger)
        {
            _tokenService = tokenService;
            _logger = logger;

        }

        [HttpGet]
        [Route("GetLoggedUser")]
        [AllowAnonymous]
        public string GetLoggedUser()
        {
            string UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            return UserName;
        }

        [HttpPost]
        [Route("AccessToken")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AccessToken(string user)
        {


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = _tokenService.GenerateToken(user);


            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("Empregado")]
        [Authorize(Roles = "EMPREGADO")]
        public string Empregado() => "Empregado";

        [HttpGet]
        [Route("Gestor")]
        [Authorize(Roles = "GESTOR")]
        public string Gestor() => "Gestor";

    }
}