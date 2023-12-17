using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ShopTB.Model.DTO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShopTB.sakila;

namespace ShopTB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        ShoptbContext MyDBContext;

        public LoginController (IConfiguration configuration, ShoptbContext myDBContext)
        {
            _configuration = configuration;
            this.MyDBContext = myDBContext;
        }
        [HttpGet("getuser")]
        public IActionResult Get()
        {
            var user = MyDBContext.Users.FirstOrDefault(x => x.Id == 1);
            return new JsonResult(new { mess = user.UserName });
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] loginDTO model)
        {
            var passMD_5 = ComputeMD5(model.password);

            var user = MyDBContext.Users.FirstOrDefault(x => x.Password == passMD_5);

            if (user != null)
            {
                var token = CreateToken(user);
                return new JsonResult(new { mess = "login success", token = token, breakline = "" } );
            }
            else
                return new JsonResult(new { mess = "Tên đăng nhập hoặc mật khẩu không đúng !" });
        }
        [NonAction]
        static string ComputeMD5(string s)
        {
            StringBuilder sb = new StringBuilder();

            // Initialize a MD5 hash object
            using (MD5 md5 = MD5.Create())
            {
                // Compute the hash of the given string
                byte[] hashValue = md5.ComputeHash(Encoding.UTF8.GetBytes(s));

                // Convert the byte array to string format
                foreach (byte b in hashValue)
                {
                    sb.Append($"{b:X2}");
                }
            }

            return sb.ToString();
        }
        [NonAction]
        private string CreateToken(User user)
        {
            var role = MyDBContext.UserRoles.Include("Role").FirstOrDefault(x => x.UserId == user.Id);
            List<Claim> claims = new List<Claim> { 
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, role.Role.RoleName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var signKey = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                signingCredentials: signKey,
                claims: claims,
                expires: DateTime.Now.AddMinutes(10));
            var shopTBToken = new JwtSecurityTokenHandler().WriteToken(token);
            return shopTBToken;
        }
    }
}
