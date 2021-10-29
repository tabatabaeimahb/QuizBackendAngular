using Amazon.SecurityToken.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Backend.Controllers
{
    public class Credentioals
    {
        public string Email { get; set; }
        public string pass { get; set; }

    }
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private SignInManager<IdentityUser> signInManager;
        private UserManager<IdentityUser> userManager;

        public AccountController (UserManager<IdentityUser> userManager , 
                                  SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [HttpPost]
        public async Task<ActionResult> register([FromBody] Credentioals credentials)
        {
            try
            {
                var user = new IdentityUser() { Email = credentials.Email, UserName = credentials.Email };
                //کاربر را ثبت نام می کند
                var result = await userManager.CreateAsync(user, credentials.pass);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                //بعد از ثبت نام کاربر حالا لاگین کند  و چون می خواهیم از کوکی استفاده نکنیم پارامتر دوم را فالس می زنیم
                await signInManager.SignInAsync(user, isPersistent: false);

                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is the secret key"));
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

                //ایدی کاربر را به توکن داده تا بتوان براساس ان داده ها را واکشی کرد
                var claims = new Claim[]
                 {
                     new Claim (JwtRegisteredClaimNames.Sub,user.Id)
                 };

       
                var jwt = new JwtSecurityToken(signingCredentials: signingCredentials,claims: claims);

                Console.Write(jwt);

                return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
            }
            catch (Exception ep)
            {

                Console.Write(ep.Message);
                return BadRequest(ep);
            }
           
        }
        [HttpPost(template:"login")]
        public async Task<ActionResult> login([FromBody] Credentioals credentials)
        {
            //جستجو کن براساس این ایمیل و پسوورد کاربری قبلا ثبت نام کرده یا خیر
            var result = await signInManager
                               .PasswordSignInAsync(credentials.Email, credentials.pass, false, false);

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            //کاربر را پیدا کن
            var user = await userManager.FindByEmailAsync(credentials.Email);

            return Ok(createtoken(user));

          
        }
        public string createtoken(IdentityUser user)
        {

            //ایدی کاربر را به توکن داده تا بتوان براساس ان داده ها را واکشی کرد
            var claims = new Claim[]
                 {
                     new Claim (JwtRegisteredClaimNames.Sub,user.Id)
                 };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is the secret key"));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(signingCredentials: signingCredentials, claims: claims);

            Console.Write(jwt);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    } 
}
