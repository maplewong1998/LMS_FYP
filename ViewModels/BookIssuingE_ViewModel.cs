using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.ViewModels
{
    public class BookIssuingE_ViewModel
    {
        public string id { get; set; }
        public string member_email { get; set; }
        public string book_id { get; set; }
        public string issue_date { get; set; }
        public string due_date { get; set; }
        public string issue_status { get; set; }
        public string member_name { get; set; }
        public string book_name { get; set; }
    }
}
