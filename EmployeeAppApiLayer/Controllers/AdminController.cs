using EmployeeAppModels;
using EmployeeAppRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeAppApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
    
            private readonly EmployeeDbContext data_Context;
            private readonly IConfiguration _config;
        public AdminController(EmployeeDbContext dContext, IConfiguration configuration)
            {
                data_Context = dContext;
                _config = configuration;
            }
        public static Verify verify = new Verify();

        [HttpPost("register")]
            public async Task<IActionResult> Register(UserLogin request)
            {
                if (data_Context.Verification.Any(u => u.VUserName == request.UserName))
                {
                    return BadRequest("User already exist");
                }

                CreatePasswordHash(request.Password
                    , out byte[] passwordHash
                    , out byte[] passwordSalt);

                var verify = new Verify
                {
                    VUserName = request.UserName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                   
                };

                data_Context.Verification.Add(verify);
                await data_Context.SaveChangesAsync();
                return Ok("user Succesfully created");
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login(UserLogin request1)
            {

                var user = await data_Context.Verification.FirstOrDefaultAsync(u => u.VUserName == request1.UserName);
                if (user == null)
                {
                    return BadRequest("User not found");
                }

                if (!VerifyPasswordHash(request1.Password, user.PasswordHash, user.PasswordSalt))
                {
                    return BadRequest("Password is Incorrect");
                }
                
                string token = CreateToken(user);

                return Ok(token);



        }
        private string CreateToken(Verify user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.VUserName),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }



        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
            {
                using (var hmac = new HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.
                        ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                }
            }

            private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
            {
                using (var hmac = new HMACSHA512(passwordSalt))
                {
                    var computedHash = hmac.
                        ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    return computedHash.SequenceEqual(passwordHash);

                }
            }



         

        }
    }
