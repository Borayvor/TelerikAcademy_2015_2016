namespace UserVoiceSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "AuthorEmail")]
        public string Email { get; set; }
    }
}
