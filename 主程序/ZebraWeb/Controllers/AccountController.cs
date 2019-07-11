using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELearning.DataAccess.Seeds;
using ELearning.ORM.SqlServer;
using ELearning.UserAndRole;
using ELearning.ViewModels.Common;
using ELearning.ViewModels.UserAndRole;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ZebraWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly SqlServerDbContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
         UserManager<ApplicationUser> userManager,
         RoleManager<ApplicationRole> roleManager,
         SignInManager<ApplicationUser> signInManager,
         SqlServerDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            ApplicationDataSeed.ForRolesAndUsers(_roleManager, _userManager);
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
            {    // 提取用户对象
                var user = await _userManager.FindByNameAsync(loginVM.UserName);

                if (user != null)
                {
                    // 检查用户是否被锁定
                    if (user.LockoutEnabled)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, loginVM.RememberMe, lockoutOnFailure: false);
                        HttpContext.Session.SetString("User", user.Id.ToString());
                        var ll = HttpContext.Session.GetString("User");
                        //if (result.Succeeded)
                        //{
                        if (!String.IsNullOrEmpty(loginVM.ReturnUrl))
                        {
                            return RedirectToAction("Index", "index", user);
                        }
                        else
                        {

                            ViewData["userinfo"] = user;

                            HttpContext.Session.SetString("User",user.Id.ToString());
                            var tt= HttpContext.Session.GetString("User");
                            if (await _userManager.IsInRoleAsync(user, "普通注册用户"))
                            {

                                return Redirect(loginVM.ReturnUrl);
                            }
                            else if (await _userManager.IsInRoleAsync(user, "小编用户"))
                            {
                                return RedirectToAction("Index", "index");
                            }
                            else if (await _userManager.IsInRoleAsync(user, "景区管理用户"))
                            {
                                return RedirectToAction("index", "Home");
                            }
                            else
                            {
                                return RedirectToAction("index", "Index");

                            }
                        }
                        //}


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
            else { return View(loginVM); }
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            var userVM = new ApplicationUserVM();
            return View(userVM);
        }
        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUserVM userVM)
        {
            if (ModelState.IsValid)
            {

                var normalUser = new ApplicationUser()
                {

                    UserName = userVM.Name,
                    Phone = long.Parse(userVM.Phone),
                    LockoutEnabled = false,
                    Sex = userVM.Sex
                };
                var name = _context.Users.SingleOrDefault(x => x.Name == userVM.Name);
                if (name == null)
                {
                    await _userManager.CreateAsync(normalUser, "123@Abc");
                    await _userManager.AddToRoleAsync(normalUser, "普通注册用户");
                    ViewData["UserInfo"] = normalUser;
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Index");
                }


                // 提取用户对象
                //var user = await _userManager.FindByEmailAsync(userVM.Email);
                //if (user != null)
                //{
                //    var result = await _signInManager.PasswordSignInAsync(user, userVM.Password, false, lockoutOnFailure: false);

                //    return RedirectToAction("Home,index");
                //}
                //else
                //{
                //}
                //return RedirectToAction("Index");
            }
            return View(userVM);
        }
    }
}