using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HRSW2.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using HRSW2.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRSW2.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public HomeController(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
     
   
      
        private  void Authenticate(string rolename)
        {
            var roleClaim = new List<Claim>()
            {             
                new Claim( ClaimTypes.Role , rolename),              
               
            };
            var roleIdentity = new ClaimsIdentity(roleClaim, "Role Identity");        
            var userPrincipal = new ClaimsPrincipal(new[] { roleIdentity });
            HttpContext.SignInAsync(userPrincipal);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username , string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            
            if (user != null)
            {
                var role = await _userManager.GetRolesAsync(user);
            
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                var rolename = await _userManager.GetRolesAsync(user);
                if (rolename != null)
                Authenticate(rolename[0]);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }
      
        public  IActionResult Register()
        {
           
            var rolename =  _roleManager.Roles;
            List<SelectListItem> listRole = new List<SelectListItem>();
          

            foreach (var role in rolename)
            {                
                listRole.Add( new SelectListItem {Value = role.Name , Text = role.Name } );
            }
          
            ViewBag.listRole = listRole;
            
            return View();
        }

      
        [HttpPost]
        public async Task<IActionResult> Register(string username , string password, string rolename)
        {
            var user = new AppUser
            {
                UserName = username

            };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                var currentUser =  await _userManager.FindByNameAsync(user.UserName);
                var roleResult = await  _userManager.AddToRoleAsync(currentUser, rolename);
                var rsult = await _userManager.GetRolesAsync(currentUser);
                
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return View();
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
