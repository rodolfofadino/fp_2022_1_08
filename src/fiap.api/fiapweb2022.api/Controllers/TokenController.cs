using fiapweb2022.api.Models;
using fiapweb2022.core.Contexts;
using fiapweb2022.core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace fiapweb2022.api.Controllers
{
    [ApiController]
    [Route("/token")]
    public class TokenController : Controller
    {
        private CopaContext _context;

        public TokenController(CopaContext context)
        {
            _context = context;

        }

        [HttpPost]
        public async Task<IActionResult> Create(TokenInfo model)
        {
            if (IsValid(model))
            {
                if (model.GrantType == "refreshToken")
                {
                    var expired = _context.TokensStores.FirstOrDefault(a => a.RefreshToken == model.RefreshToken && a.Used == false);
                    if (expired != null)
                    {
                        expired.Used = true;
                        await _context.SaveChangesAsync();
                        model.UserName = expired.UserName;
                    }
                }

                var token = GenerateToken(model);
                var refreshToken = Guid.NewGuid().ToString().Replace("-", String.Empty);


                var tokenStore = new TokenStore()
                {
                    UserName = model.UserName,
                    Token = token,
                    RefreshToken = refreshToken,
                };
                await _context.AddAsync(tokenStore);
                await _context.SaveChangesAsync();


                return new ObjectResult(new { Token = token, RefreshToken = refreshToken });

            }

            return BadRequest();
        }

        private string GenerateToken(TokenInfo model)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Name, model.UserName),
                new Claim(JwtRegisteredClaimNames.Nbf,new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp,new DateTimeOffset(DateTime.Now.AddMinutes(1)).ToUnixTimeSeconds().ToString()),
            };
            var key = new SymmetricSecurityKey(Security.GetKey());
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);
            var payload = new JwtPayload(claims);
            var token = new JwtSecurityToken(header, payload);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool IsValid(TokenInfo model)
        {
            if (model.GrantType == "refreshToken")
            {
                var expiredToken = _context.TokensStores.FirstOrDefault(a => a.RefreshToken == model.RefreshToken && a.Used == false);

                return expiredToken != null;
            }

            return model.UserName == model.Password;
        }
    }
}
