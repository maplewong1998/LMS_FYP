using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class BookIssueModel
    {
        [Column(TypeName = "nvarchar(50)")]
        [Key]
        public string id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string member_email { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string book_isbn { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string issue_date { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string due_date { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string issue_status { get; set; }
    }
}
