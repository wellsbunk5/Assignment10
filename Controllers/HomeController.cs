using Assignment10.Models;
using Assignment10.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Controllers
{
    // Home Controller
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext _context;

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext context)
        { // get the Db context into the controller from the constructor
            _logger = logger;
            _context = context;
        }

        // The Index or main action
        public IActionResult Index(long? teamid, string teamName, int pageNum = 1)
        {
            int pageSize = 5;

            return View(new IndexViewModel
            {
                // put in page info
                PageNumInfo = new PageNumInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = (teamid == null ? _context.Bowlers.Count() : _context.Bowlers.Where(x => x.TeamId == teamid).Count())
                },
                // grab the bowlers
                Bowlers = (_context.Bowlers
                .Where(x => x.TeamId == teamid || teamid == null)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList()),
                // did they select a team?
                TeamName = teamName
            });
                
                
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
