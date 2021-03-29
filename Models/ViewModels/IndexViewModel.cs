using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Models.ViewModels
{
    public class IndexViewModel
    {
        // View Model we need to use
        public IEnumerable<Bowlers> Bowlers { get; set; }
        public PageNumInfo PageNumInfo { get; set; }
        public string TeamName { get; set; }
    }
}
