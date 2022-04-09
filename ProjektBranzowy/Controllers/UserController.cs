using ProjektBranzowy.Models;
using ProjektBranzowy.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektBranzowy.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _db;
    public UserController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<User> objList = _db.People;
            return View(objList);
        }
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {
            _db.People.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
