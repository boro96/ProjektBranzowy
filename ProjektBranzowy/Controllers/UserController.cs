using Microsoft.AspNetCore.Mvc;
using ProjektBranzowy.DataAccess;
using ProjektBranzowy.Models;
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


        public IActionResult Update(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.People.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult UpdatePost(User obj)
        {
            if(ModelState.IsValid)
            {
                _db.People.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(obj);
        }
    }
}
