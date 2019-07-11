using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELearning.ORM.SqlServer;
using ELearning.UserAndRole;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ZebraWeb.Controllers
{
    public class IndexController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly SqlServerDbContext _context;

        public IndexController(UserManager<ApplicationUser> userManager,
         RoleManager<ApplicationRole> roleManager,
         SignInManager<ApplicationUser> signInManager, SqlServerDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Index()
        {

            var UserId = HttpContext.Session.GetString("User");
            if (UserId != null)
            {
              var User = _context.ApplicationUsers.SingleOrDefault(x => x.Id == Guid.Parse(UserId));
              ViewData["userinfo"] = User;
              ViewBag.img = User.HerdPortrait;
            }

            return View(_context.ScenicSpot.Include(x => x.Theme).Include(x => x.Label));
        }
    }
}