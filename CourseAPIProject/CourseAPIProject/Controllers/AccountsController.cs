using CourseAPIProject.Core.Entities;
using CourseAPIProject.Service.Dtos.Account;
using CourseAPIProject.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CourseAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountsController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
        }
        //[HttpGet]
        //public async Task<IActionResult> CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //    await _roleManager.CreateAsync(new IdentityRole("Member"));
        //    return Ok();
        //}
        //[HttpGet("Admincreate")]
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser user=new AppUser();
        //    user.UserName= "admin1";
        //    user.FullName = "Behruz Rehimov";
        //    user.Email = "behruzrehimov@mail.ru";
        //    await _userManager.CreateAsync(user,"admin123");
        //    await _userManager.AddToRoleAsync(user, "Admin");
        //    return Ok();
        //}
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            AppUser admin =await _userManager.FindByNameAsync(dto.Usermane);
            if (admin==null)
            {
                return NotFound();
            }
            if (!_userManager.CheckPasswordAsync(admin,dto.Password).Result)
            {
                return StatusCode(401);
            }
            List<Claim> claims= new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, admin.Id));
            claims.Add(new Claim(ClaimTypes.Name, admin.UserName));
            claims.Add(new Claim(ClaimTypes.Email, admin.Email));
            claims.Add(new Claim("FullName", admin.FullName));

            var roles = (_userManager.GetRolesAsync(admin).Result).Select(x=> new Claim(ClaimTypes.Role,x)).ToList();
            claims.AddRange(roles);

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Secret").Value));
            var creds=new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                signingCredentials:creds,
                claims:claims,
                expires: DateTime.UtcNow.AddDays(3),
                issuer: _configuration.GetSection("JWT:Issuer").Value,
                audience: _configuration.GetSection("JWT:Audience").Value
                );
            string tokenstr=new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { token=tokenstr });

        }

    }
}
