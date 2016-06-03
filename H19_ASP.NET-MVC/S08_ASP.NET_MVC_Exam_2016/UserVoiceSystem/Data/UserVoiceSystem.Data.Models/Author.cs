namespace UserVoiceSystem.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Author : BaseModel<int>
    {
        [MaxLength(50)]
        public string UserId { get; set; }

        [Required]
        [MaxLength(16)]
        [Index(IsUnique = true)]
        public string Ip { get; set; }

        [MaxLength(500)]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9A-Za-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9A-Za-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9A-Za-z][-\w]*[0-9A-Za-z]*\.)+[A-Za-z0-9][\-a-zA-Z0-9]{0,22}[A-Za-z0-9]))$", ErrorMessage = "Invalid Email address !")]
        public string Email { get; set; }

        [Range(0, 10, ErrorMessage = "Out of range !")]
        [DefaultValue(10)]
        public int VotePoints { get; set; }
    }
}
