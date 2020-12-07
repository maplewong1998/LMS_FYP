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
        [Required]
        public string issue_id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string member_id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string book_id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string issue_date { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string due_date { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string issue_status { get; set; }
    }
}
