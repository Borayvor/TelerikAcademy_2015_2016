namespace UserVoiceSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Vote : BaseModel<int>
    {
        [Required]
        [MaxLength(16)]
        public string AuthorIp { get; set; }

        [Range(1, 3, ErrorMessage = "Out of range !")]
        public int Points { get; set; }

        public int IdeaId { get; set; }

        public virtual Idea Idea { get; set; }
    }
}
