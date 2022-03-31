using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySQLPractice.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLPractice.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }
        private BowlersDbContext _context { get; set; }

        public HomeController(BowlersDbContext temp, IBowlersRepository temp2)
        {
            _context = temp;
            _repo = temp2;

        }

        public IActionResult Index2()
        {

            var bowl = _context.Bowlers.ToList();

            return View(bowl);
        }

        public IActionResult Index(int? teamID)
        {
            string blah = "Team Name";
            if (teamID == 1)
            {
                blah = "Marlins";
            }
            if (teamID == 2)
            {
                blah = "Sharks";
            }
            if (teamID == 3)
            {
                blah = "Terrapins";
            }
            if (teamID == 4)
            {
                blah = "Barracudas";
            }
            if (teamID == 5)
            {
                blah = "Dolphins";
            }
            if (teamID == 6)
            {
                blah = "Orcas";
            }
            if (teamID == 7)
            {
                blah = "Manatees";
            }
            if (teamID == 8)
            {
                blah = "Swordfish";
            }
            if (teamID == 9)
            {
                blah = "Hucckleberrys";
            }
            if (teamID == 10)
            {
                blah = "MintJuleps";
            }


            if (teamID == null)
            {
                var bowl = _repo.Bowlers.ToList();
                return View(bowl);
            }
            else
            {
                var bowl = _repo.Bowlers.ToList().Where(x => x.TeamID == teamID);
                return View(bowl);
            }

            
        }

        [HttpGet]
        public IActionResult Edit(int bowlerID, int? teamId)
        {
            var bowl = _repo.GetBowler(bowlerID);

            return View(bowl);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            _repo.SaveBowler(b);

            var bowl = _repo.Bowlers.ToList();

            return RedirectToAction("Index", bowl);
        }

        public IActionResult Delete(Bowler b)
        {
            _repo.DeleteBowler(b);

            var bowl = _repo.Bowlers.ToList();

            return View("Index", bowl);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Edit");
        }

    }
}
