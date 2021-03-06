﻿namespace UserVoiceSystem.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "AuthorEmail")]
        public string Email { get; set; }
    }
}
