using Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PromoCodeService.Models.Config;
using PromoCodeService.Models.DTO;
using PromoCodeService.Models.Response;

namespace PromoCodeService.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly JWTConfig _configuration;
        private readonly DataContext _context;

        public AuthController(
            UserManager<User> userManager,
            IOptions<JWTConfig> configuration,
            DataContext dataContext
            )
        {
            _userManager = userManager;
            _configuration = configuration.Value;
            _context = dataContext;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            // a123456A!
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);

                if (isPasswordValid)
                {
                    return Ok(await MakeLoginResponse(user));
                }
            }
            return Unauthorized();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("refresh")]
        public async Task<IActionResult> RefreshWithCookie()
        {
            string refreshToken;
            Request.Cookies.TryGetValue("refreshToken", out refreshToken);
            IActionResult result = Unauthorized();

            if (!String.IsNullOrEmpty(refreshToken))
            {
                // TODO: USE UA TO NOT CLUTTER DB
                var t = await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken);
                if (t != null)
                {
                    var user = await _userManager.FindByIdAsync(t.UserId);
                    if (!t.Expired && user != null)
                    {
                        result = Ok(await MakeLoginResponse(user));
                    }

                    _context.Remove(t);
                    await _context.SaveChangesAsync();
                }
            }

            return result;
        }

        private async Task<LoginResponse> MakeLoginResponse(User user, bool saveRefreshToken = true)
        {
            var tokens = GetAccessTokenForUser(user);
            var accessToken = tokens.AccessToken;
            var refreshToken = tokens.RefreshToken;

            if (saveRefreshToken)
            {
                _context.RefreshTokens.Add(tokens.RefreshToken);
                await _context.SaveChangesAsync();
            }

            SetRefreshTokenCookie(refreshToken);

            return new LoginResponse
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                Expires = accessToken.ValidTo,
                RefreshToken = refreshToken.Token
            };
        }

        private void SetRefreshTokenCookie(RefreshToken refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = refreshToken.Expires
            };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }

        private UserTokens GetAccessTokenForUser(User user)
        {

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Secret));


            var claims = new Claim[]
               {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
               };

            return new UserTokens
            {
                AccessToken = new JwtSecurityToken(
                    issuer: _configuration.Issuer,
                    claims: claims,
                    audience: _configuration.Audience,
                    expires: DateTime.Now.AddMinutes(_configuration.AccessTokenLifeTime),
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                ),
                RefreshToken = new RefreshToken
                {
                    UserId = user.Id,
                    Expires = DateTime.Now.AddMinutes(_configuration.RefreshTokenLifeTime),
                    UserAgent = HttpContext.Request.Headers["user-agent"][0] ?? "",
                }
            };
        }

        struct UserTokens
        {
            public JwtSecurityToken AccessToken;
            public RefreshToken RefreshToken;
        }
    }
}
