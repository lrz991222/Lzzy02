using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELearning.UserAndRole;
using ELearning.ViewModels.Common;
using ELearning.ViewModels.UserAndRole;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ELZebra.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

       
        public AccountController(
         SignInManager<ApplicationUser> signInManager,
         UserManager<ApplicationUser> userManager,
         RoleManager<ApplicationRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
             
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Logon(string returnUrl)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            return View(new LoginVM() { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Logon(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                // 提取用户对象
                var user = await _userManager.FindByNameAsync(loginVM.UserName);
                if (user != null)
                {
                    // 检查用户是否被锁定
                    if (user.LockoutEnabled)
                    {
                        // 登录系统
                        var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, lockoutOnFailure: false);
                        if (result.Succeeded)
                        {
                            if (!String.IsNullOrEmpty(loginVM.ReturnUrl))
                                return Redirect(loginVM.ReturnUrl);
                            else
                                return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("Password", "输入密码错误，请核实后重新输入。");
                            return View(loginVM);
                        }
                    }
                    else
                    {
                        ViewData["LoginStatusString"] = "用户已被锁定，无法登录!";
                        return View(loginVM);
                    }
                }
                else
                {
                    ViewData["LoginStatusString"] = "用户名或者密码错误。";
                    return View(loginVM);
                }

            }
            ViewData["LoginStatusString"] = "";
            return View(loginVM);
        }
    }
}