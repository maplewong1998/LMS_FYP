using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using LMS.Areas.Identity.Models;
using LMS.Utility;

namespace LMS.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AppUserModel> _signInManager;
        private readonly UserManager<AppUserModel> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<AppUserModel> userManager,
            SignInManager<AppUserModel> signInManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Full Name")]
            public string full_name { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Birth Date")]
            public string dob { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Contact Number")]
            public string contact_no { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Street")]
            public string street { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "State")]
            public string state { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "City")]
            public string city { get; set; }

            [Required]
            [DataType(DataType.PostalCode)]
            [Display(Name = "Postcode")]
            public int postcode { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(15, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new AppUserModel { 
                    UserName = Input.Email,
                    Email = Input.Email,
                    full_name = Input.full_name,
                    dob = Input.dob,
                    PhoneNumber = Input.contact_no,
                    street = Input.street,
                    state = Input.state,
                    city = Input.city,
                    postcode = Input.postcode,
                    account_status = "pending",
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (!await _roleManager.RoleExistsAsync(AppConstants.AdminEndUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(AppConstants.AdminEndUser));
                    }
                    if (!await _roleManager.RoleExistsAsync(AppConstants.MemberEndUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(AppConstants.MemberEndUser));
                    }

                    await _userManager.AddToRoleAsync(user, AppConstants.AdminEndUser);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
