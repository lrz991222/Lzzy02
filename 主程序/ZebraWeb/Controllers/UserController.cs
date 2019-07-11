using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ELearning.Entities;
using ELearning.ORM.SqlServer;
using ELearning.UserAndRole;
using ELearning.ViewModels.UserAndRole;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ZebraWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SqlServerDbContext _context;

        private readonly IHostingEnvironment _hostingEnvironment;

        public UserController(UserManager<ApplicationUser> userManager, SqlServerDbContext context, IHostingEnvironment hostingEmvoronment)
        {
            _userManager = userManager;
            _context = context;
            _hostingEnvironment = hostingEmvoronment;
        }
        //个人主页
        public IActionResult Index()
        {

            var UserId = HttpContext.Session.GetString("User");
            var User = _context.ApplicationUsers.SingleOrDefault(x => x.Id == Guid.Parse(UserId));

            ViewData["userinfo"] = User;
            ViewBag.img = User.HerdPortrait;
         
            return View(User);
        }
        //个人信息
        public IActionResult UserInfo()
        {
            var UserId = HttpContext.Session.GetString("User");
            var User = _context.ApplicationUsers.SingleOrDefault(x => x.Id == Guid.Parse(UserId));

            ViewData["userinfo"] = User;
            ViewBag.img = User.HerdPortrait;

            return View(User);
        }
        [HttpPost]
        public IActionResult UserInfo(ApplicationUser user, List<IFormFile> file)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;

            var UserId = HttpContext.Session.GetString("User");
            if (user != null)
            {
                var User = _context.ApplicationUsers.SingleOrDefault(x => x.Id == Guid.Parse(UserId));
                User.Name = user.Name;
                User.Phone = user.Phone;
                User.Email = user.Email;
                User.Sex = user.Sex;

                if (file.Count > 0)
                {
                    int g = file[0].FileName.LastIndexOf(".");
                    string newFileName = UserId.ToString() + file[0].FileName.Substring(g);
                    var filePath = webRootPath + "/Images/" + newFileName;
                    User.HerdPortrait = "/Images/" + newFileName;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file[0].CopyTo(stream);
                    }
                }

                _context.SaveChanges();
                ViewData["userinfo"] = User;
                ViewBag.img = User.HerdPortrait;
            }
            return RedirectToAction("Index", "index", user);
        }
        public   IActionResult  GoWith()
        {
          
            var UserId = HttpContext.Session.GetString("User");
            if (UserId != null)
            {
                var User = _context.ApplicationUsers.SingleOrDefault(x => x.Id == Guid.Parse(UserId));
                ViewData["userinfo"] = User;
                ViewBag.img = User.HerdPortrait;
            }
            ViewBag.Citys = _context.Citys;
            return View();
        }
        [HttpPost]
        public IActionResult GoWith(GoWith goWith)
        {
            var City= _context.Citys.SingleOrDefault(x => x.CityName == goWith.City.CityName);

            return View();
        }
            public async Task<IActionResult> Travel()
        {
            var UserId = HttpContext.Session.GetString("User");
            if (UserId != null)
            {
                var User = _context.ApplicationUsers.SingleOrDefault(x => x.Id == Guid.Parse(UserId));
                ViewData["userinfo"] = User;
                ViewBag.img = User.HerdPortrait;
            }
            return View();
        }


    }
}