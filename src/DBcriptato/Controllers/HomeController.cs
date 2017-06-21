using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DBcriptato.Data;
using Microsoft.AspNetCore.Identity;
using DBcriptato.Models;
using Microsoft.EntityFrameworkCore;

namespace DBcriptato.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager, ApplicationDbContext idb)
        {
            _userManager = userManager;
            db = idb;
        }

        public ViewResult Index()
        {
            return View();
        }

        public IActionResult Visualize()
        {
            var userId = _userManager.GetUserId(User); // Get user id:
            var userKey = db.Users.Where(c => c.Id == userId).FirstOrDefault();
            if (userKey.hashKey == null)
            {
                return RedirectToAction("AddKey");
            }
            var allData = db.ciphertexts.ToList();
            return View(allData);
        }

        [HttpGet]
        public IActionResult Confidential()
        {
            var userId = _userManager.GetUserId(User); // Get user id:
            var userKey = db.Users.Where(c => c.Id == userId).FirstOrDefault();
            if (userKey.hashKey == null)
            {
                return RedirectToAction("AddKey");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Confidential([FromBody] Ciphertext ct)
        {
            var userId = _userManager.GetUserId(User); // Get user id:
            var uKey = db.Users.Where(c => c.Id == userId).FirstOrDefault();
            ct.Id = uKey.Id;
            db.ciphertexts.Add(ct);
            db.SaveChanges();
            return Json(new { success = true });
        }

        [HttpGet]
        public IActionResult AddKey()
        {
            var userId = _userManager.GetUserId(User); // Get user id:
            var userKey = db.Users.Where(c => c.Id == userId).FirstOrDefault();
            if (userKey.hashKey != null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddKey([FromBody]string key) // Key è l'hash della chiave serve solo per controllare che l'utente non sbagli
        {
            var userId = _userManager.GetUserId(User); // Get user id:
            var userKey = db.Users.Where(c => c.Id == userId).FirstOrDefault();
            userKey.hashKey = key;
            db.Users.Update(userKey);
            db.SaveChanges();
            return Json(true);
        }
        
        [HttpPost]
        public IActionResult CheckKey([FromBody]string key)
        {
            var userId = _userManager.GetUserId(this.User);
            var uKey = db.Users.Where(c => c.Id == userId).FirstOrDefault();
            if(uKey.hashKey == key)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
