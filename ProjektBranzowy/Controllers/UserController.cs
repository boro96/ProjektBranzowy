using ProjektBranzowy.Models;
using ProjektBranzowy.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            IEnumerable<LogHistory> objList = _db.LogsHistory.Include(x => x.Room).Include(a => a.User);
            return View(objList);
        }
        public IActionResult Create()
        {
           
            return View();
        }

        public IActionResult Delete()
        {
            IEnumerable<User> list = _db.People.ToList<User>();
            return View(list);
        }

            [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {
            obj.GroupId = 1;
            _db.People.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        
        
        [HttpPost]
        public IActionResult DeleteUsers(IEnumerable<int> id)
        {
            IEnumerable<User> list = _db.People.Where(user => id.Contains(user.UserId)).ToList();
            foreach (User u in list)
            {
                _db.People.Remove(u);
                _db.SaveChanges();
               
            }
            return RedirectToAction("Delete");
        }
      
    }
}
