namespace UserVoiceSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "AuthorEmail")]
        public string Email { get; set; }
    }
}
