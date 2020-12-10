using LMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.ViewModels
{
    public class BookInventoryViewModel
    {
        public IEnumerable<BookModel> book_list { get; set; }
    }
}
