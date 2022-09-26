using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTS_EntityFrameworks.Models
{
    public class SelectFromList
    {
        public Department Department { get; set; }
        public Region Region { get; set; }
        public IEnumerable<SelectListItem> Divisions { get; set; }
    }
}
