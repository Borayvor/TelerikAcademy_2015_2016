namespace UserVoiceSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Comment : BaseModel<int>
    {
        [Required]
        [MaxLength(10000)]
        [MinLength(5)]
        public string Content { get; set; }

        [Required]
        [MaxLength(16)]
        public string AuthorIp { get; set; }

        [MaxLength(500)]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9A-Za-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9A-Za-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9A-Za-z][-\w]*[0-9A-Za-z]*\.)+[A-Za-z0-9][\-a-zA-Z0-9]{0,22}[A-Za-z0-9]))$", ErrorMessage = "Invalid Email address !")]
        public string AuthorEmail { get; set; }

        public int IdeaId { get; set; }

        public virtual Idea Idea { get; set; }
    }
}
