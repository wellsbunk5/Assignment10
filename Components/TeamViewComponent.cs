﻿using Assignment10.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext _context;
        public TeamViewComponent (BowlingLeagueContext context)
        {
            _context = context;
        }


        public IViewComponentResult Invoke()
        {      
            // set the selected category == to whatever the category they want is
            ViewBag.SelectedTeam = RouteData?.Values["teamName"];

            return View(_context.Teams
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
