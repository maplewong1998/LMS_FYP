using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class LanguageList
    {
        public List<SelectListItem> language_list { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "English", Text = "English" },
            new SelectListItem { Value = "Malay", Text = "Malay" },
            new SelectListItem { Value = "Chinese", Text = "Chinese" },
            new SelectListItem { Value = "Hindi", Text = "Hindi" },
        };
    }
}
