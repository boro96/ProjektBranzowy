using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjektBranzowy.DataAccess;
using ProjektBranzowy.Models;

namespace ProjektBranzowy.Controllers
{
    public class PrivacyController : Controller
    {
        private readonly DataContext _db;

        public PrivacyController(DataContext db)
        {
            _db = db;
        }
        public IActionResult UnauthorizedAccess()
        {
            
            IEnumerable<UnauthorizedAccess> unauthorizedAcceses = _db.UnauthorizedAccess.Include(x => x.Room).Include(a => a.User);
           

            return View(unauthorizedAcceses);
        }

        public IActionResult ScheduleRooms()
        {

            IEnumerable<ScheduleRoom> unauthorizedAcceses = _db.ScheduleRooms.Include(x => x.Room);
            return View(unauthorizedAcceses);
        }

        


        private bool DuringSchadule(Schedule schadule, DateTime dateTime)
        {
            DateTime morning = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
            TimeSpan time = dateTime - morning;
            return schadule.Start <= time && time <= schadule.Finish;
        }

        public IActionResult Index()
        {
            IEnumerable<LogHistory> objList = _db.LogsHistory.Include(x => x.Room).Include(a => a.User);
            return View(objList);
        }
    }
}
