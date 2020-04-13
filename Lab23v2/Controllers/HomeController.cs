using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab23v2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics.Eventing.Reader;
using System.Net.Cache;
using Microsoft.AspNetCore.Http;

namespace Lab23v2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Lab23v2Context DB = new Lab23v2Context();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeNewUser(Users user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            DB.Users.Add(user);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VerifyLogin(string email, string pass)
        {
            var data = DB.Users.Find(email);
            if (data.Pass == pass)
            {
                HttpContext.Session.SetString("First Name", data.Fname.ToString());
                HttpContext.Session.SetString("Wallet", data.Wallet.ToString());
                HttpContext.Session.SetString("Email", data.Email.ToString());
                return RedirectToAction("Shop");
            }
            else
            {
            return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Users()
        {
            return View();
        }
        
        public IActionResult Shop()
        {
            return View("Items/Index");
        }
    }
}
