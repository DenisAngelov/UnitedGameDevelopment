namespace UnitedGameDevelopment.Models.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Register as Company:")]
        public bool IsCompany { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name must be at least 3 characters long and not more than 50 characters long.", MinimumLength = 3)]
        [Display(Name = "Username")]
        public string Username { get; set; }
    }
}