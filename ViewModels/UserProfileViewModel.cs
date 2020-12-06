using LMS.Areas.Identity.Models;
using LMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.ViewModels
{
    public class UserProfileViewModel
    {
        public AppUserModel user { get; set; }
        public IEnumerable<BookIssueModel> issued_books { get; set; }

        [StringLength(15, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String ChangePassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("ChangePassword", ErrorMessage = "The password and confirmation password do not match.")]
        public String ConfirmPassword { get; set; }
    }
}
