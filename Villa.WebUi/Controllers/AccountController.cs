using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Security.Claims;
using Villa.Dto.Dtos.IdentityDtos;
using Villa.Entity.Entites;

namespace Villa.WebUi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager=userManager;
            _signInManager=signInManager;
        }

        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                NameSurname=registerDto.NameSurname,
                Email=registerDto.Email,
                UserName=registerDto.UserName,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View();
            }

            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginDto Input)
        {


            var result = await _signInManager.PasswordSignInAsync(Input.UserName,
                           Input.Password, true, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home"); // Change this according to your application's structure
            }

            if (result.IsLockedOut)
            {
                return View(Input);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View();
            }

            // If we got this far, something failed, redisplay form
            //return Page();
            // Redirect to a different action or view upon successful login

            //    var user=await _userManager.FindByNameAsync(loginDto.UserName);
            //    if (user==null)
            //    {
            //        ModelState.AddModelError("", "Username or Password is Wrong");
            //        return View();
            //    }
            //    var claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, user.Email),
            //    new Claim("NameSurname", user.NameSurname),
            //    new Claim(ClaimTypes.Role, "Administrator"),
            //};

            //    var claimsIdentity = new ClaimsIdentity(
            //        claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //    var authProperties = new AuthenticationProperties
            //    {
            //        //AllowRefresh = <bool>,
            //        // Refreshing the authentication session should be allowed.

            //        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            //        // The time at which the authentication ticket expires. A 
            //        // value set here overrides the ExpireTimeSpan option of 
            //        // CookieAuthenticationOptions set with AddCookie.

            //        //IsPersistent = true,
            //        // Whether the authentication session is persisted across 
            //        // multiple requests. When used with cookies, controls
            //        // whether the cookie's lifetime is absolute (matching the
            //        // lifetime of the authentication ticket) or session-based.

            //        //IssuedUtc = <DateTimeOffset>,
            //        // The time at which the authentication ticket was issued.

            //        //RedirectUri = <string>
            //        // The full path or absolute URI to be used as an http 
            //        // redirect response value.
            //    };

            //    await HttpContext.SignInAsync(
            //        CookieAuthenticationDefaults.AuthenticationScheme,
            //        new ClaimsPrincipal(claimsIdentity),
            //        authProperties);
            //    var result=await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);
            //    if (!result.Succeeded)
            //    {
            //        ModelState.AddModelError("", "Username or Password is Wrong");
            //        return View();
            //    }
            //    return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home"); // Change this according to your application's structure
        }
    }
}
