using Backend_ApiNetCore3_1.Application.Interfaces;
using Backend_ApiNetCore3_1.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Backend_ApiNetCore3_1.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IAppUserRepository _authorizeUserRepository;

        public TokenService(IAppUserRepository authorizeUserRepository)
        {
        }
        public string GenerateToken(string login)
        {

            var roles = _authorizeUserRepository.GetAll().Where(x => x.UserEmail == login).FirstOrDefault();

            if (roles == null)
                throw new Exception("Usuário não possui permissões associadas. Favor contatar o administrador do sistema.");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Domain.Core.Settings.Secret);

            ClaimsIdentity claims = new ClaimsIdentity();

            claims.AddClaim(new Claim(ClaimTypes.Name, roles.UserEmail));

            //foreach (var profile in roles.Profiles)
            //{
            //    claims.AddClaim(new Claim(ClaimTypes.Role, profile.id));
            //}

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
