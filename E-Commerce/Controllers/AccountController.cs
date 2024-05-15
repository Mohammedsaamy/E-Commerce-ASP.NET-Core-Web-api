//using DTOs;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using Models.Model;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace E_Commerce.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AccountController : ControllerBase
//    {
//        private readonly UserManager<ApplicationUser> usermanger;
//        private readonly IConfiguration config;

//        public AccountController(UserManager<ApplicationUser> usermanger, IConfiguration config)
//        {
//            this.usermanger = usermanger;
//            this.config = config;
//        }

//        //Create Account new User "Registration" "Post"
//        [HttpPost("register")]//api/account/register
//        public async Task<IActionResult> Registration(RegisterUserDto userDto)
//        {
//            var existUser = await usermanger.FindByEmailAsync(userDto.Email);
//            if (existUser != null)
//            { 
//                return Ok(" Already Exist");
//            }

//            //save
//            var user = new ApplicationUser
//            {
//                UserName = userDto.UserName,
//                Email = userDto.Email
//            };

//            var result = await usermanger.CreateAsync(user, userDto.Password);
//            if (result.Succeeded)
//            {
//                var role = "User"; // Default role is "User"

//                // Check if the email contains "admin"
//                if (userDto.Email.ToLower().Contains("admin"))
//                {
//                    role = "Admin";
//                }

//                // Assign the role to the user
//                await usermanger.AddToRoleAsync(user, role);

//                return Ok($"User created with role: {role}");
//            }

//            return BadRequest(result.Errors.FirstOrDefault()?.Description);
//        }


//        //Check Account Valid "Login" "Post"
//        [HttpPost("login")]//api/account/login
//        public async Task<IActionResult> Login(LoginUserDto userDto)
//        {
//            if (ModelState.IsValid == true)
//            {
//                //check - create token
//                ApplicationUser user = await usermanger.FindByNameAsync(userDto.UserName);
//                if (user != null)//user name found
//                {
//                    bool found = await usermanger.CheckPasswordAsync(user, userDto.Password);
//                    if (found)
//                    {
//                        //Claims Token
//                        var claims = new List<Claim>();
//                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
//                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

//                        //get role
//                        var roles = await usermanger.GetRolesAsync(user);
//                        foreach (var itemRole in roles)
//                        {
//                            claims.Add(new Claim(ClaimTypes.Role, itemRole));
//                        }
//                        SecurityKey securityKey =
//                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));

//                        SigningCredentials signincred =
//                            new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
//                        //Create token
//                        JwtSecurityToken mytoken = new JwtSecurityToken(
//                            issuer: config["JWT:ValidIssuer"],//url web api
//                            audience: config["JWT:ValidAudiance"],//url consumer angular
//                            claims: claims,
//                            expires: DateTime.Now.AddDays(10),
//                            signingCredentials: signincred
//                            );
//                        return Ok(new
//                        {
//                            token = new JwtSecurityTokenHandler().WriteToken(mytoken),
//                            expiration = mytoken.ValidTo
//                        });
//                    }
//                }
//                return Unauthorized();

//            }
//            return Unauthorized();
//        }
//    }
//}



using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;

        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            this.userManager = userManager;
            this.config = config;
        }

        // Create Account new User "Registration" "Post"
        [HttpPost("register")] // api/account/register
        public async Task<IActionResult> Registration(RegisterUserDto userDto)
        {
            var existUser = await userManager.FindByEmailAsync(userDto.Email);
            if (existUser != null)
            {
                return Ok("Already Exist");
            }

            // Save
            var user = new ApplicationUser
            {
                UserName = userDto.UserName,
                Email = userDto.Email
            };

            var result = await userManager.CreateAsync(user, userDto.Password);
            if (result.Succeeded)
            {
                var role = "User"; // Default role is "User"

                // Check if the email contains "admin"
                if (userDto.Email.ToLower().Contains("admin"))
                {
                    role = "Admin";
                }

                // Assign the role to the user
                await userManager.AddToRoleAsync(user, role);

                return Ok($"User created with role: {role}");
            }

            return BadRequest(result.Errors.FirstOrDefault()?.Description);
        }

        // Check Account Valid "Login" "Post"
        [HttpPost("login")] // api/account/login
        public async Task<IActionResult> Login(LoginUserDto userDto)
        {
            if (ModelState.IsValid == true)
            {
                // Check and create token
                ApplicationUser user = await userManager.FindByNameAsync(userDto.UserName);
                if (user != null) // Username found
                {
                    bool found = await userManager.CheckPasswordAsync(user, userDto.Password);
                    if (found)
                    {
                        // Claims Token
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

                        // Get roles
                        var roles = await userManager.GetRolesAsync(user);
                        foreach (var itemRole in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, itemRole));
                        }

                        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));
                        SigningCredentials signincred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                        // Create token
                        JwtSecurityToken mytoken = new JwtSecurityToken(
                            issuer: config["JWT:ValidIssuer"], // URL of the web API
                            audience: config["JWT:ValidAudiance"], // URL of the consumer (e.g., Angular app)
                            claims: claims,
                            expires: DateTime.Now.AddDays(10),
                            signingCredentials: signincred
                        );
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(mytoken),
                            expiration = mytoken.ValidTo
                        });
                    }
                }
                return Unauthorized();
            }
            return Unauthorized();
        }
    }
}
