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
        public IActionResult Index(string sortOrder, string searchRoomName, string searchName, string searchSurname, DateTime? searchEntryDate, TimeSpan? searchEntryTime, DateTime? searchExitDate, TimeSpan? searchExitTime)
        {

            IEnumerable<LogHistory> objList = _db.LogsHistory.Include(x => x.Room).Include(a => a.User);
            
            if (!String.IsNullOrEmpty(searchRoomName))
            {
                objList = objList.Where(x => x.Room.Name.Contains(searchRoomName));
            }
            if (!String.IsNullOrEmpty(searchName))
            {
                objList = objList.Where(x => x.User.Name.Contains(searchName));
            }
            if (!String.IsNullOrEmpty(searchSurname))
            {
                objList = objList.Where(x => x.User.Surname.Contains(searchSurname));
            }

            DateTime entry = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (searchEntryDate.HasValue)
            {
                entry = searchEntryDate.Value;
            }
            if (searchEntryTime.HasValue)
            {
                entry.AddTicks(searchEntryTime.Value.Ticks);
            }
            if(searchEntryDate.HasValue || searchEntryTime.HasValue)
            {
                objList = objList.Where(x => x.In.CompareTo(entry)>=0);
            }

            DateTime exit = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (searchExitDate.HasValue)
            {
                exit = searchExitDate.Value;
            }
            if (searchExitTime.HasValue)
            {
                exit.AddTicks(searchExitTime.Value.Ticks);
            }
            if (searchExitDate.HasValue || searchExitTime.HasValue)
            {
                objList = objList.Where(x => x.In.CompareTo(exit) <= 0);
            }


            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "Name_asc";
            }
            ViewBag.RoomNameParm = sortOrder == "RoomName_asc" ? "RoomName_desc" : "RoomName_asc"; ;
            ViewBag.NameParm = sortOrder == "Name_asc" ? "Name_desc" : "Name_asc"; ;
            ViewBag.SurnameParm = sortOrder == "Surname_asc" ? "Surname_desc" : "Surname_asc"; ;
            ViewBag.EntryParm = sortOrder == "Entry_asc" ? "Entry_desc" : "Entry_asc"; ;
            ViewBag.ExitParm = sortOrder == "Exit_asc" ? "Exit_desc" : "Exit_asc"; ;
            //IEnumerable<LogHistory>
          
            IEnumerable<LogHistory> list = objList;
            switch (sortOrder)
            {
                case "RoomName_asc":
                    list = objList.OrderBy(x => x.Room.Name);
                    break;
                case "RoomName_desc":
                    list = objList.OrderByDescending(x => x.Room.Name);
                    break;

                case "Name_asc":
                    list = objList.OrderBy(x => x.User.Name);
                    break;
                case "Name_desc":
                    list = objList.OrderByDescending(x => x.User.Name);
                    break;

                case "Surname_asc":
                    list = objList.OrderBy(x => x.User.Surname);
                    break;
                case "Surname_desc":
                    list = objList.OrderByDescending(x => x.User.Surname);
                    break;

                case "Entry_asc":
                    list = objList.OrderBy(x => x.In);
                    break;
                case "Entry_desc":
                    list = objList.OrderByDescending(x => x.In);
                    break;

                case "Exit_asc":
                    list = objList.OrderBy(x => x.Out);
                    break;
                case "Exit_desc":
                    list = objList.OrderByDescending(x => x.Out);
                    break;


            }

            return View(list);
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
