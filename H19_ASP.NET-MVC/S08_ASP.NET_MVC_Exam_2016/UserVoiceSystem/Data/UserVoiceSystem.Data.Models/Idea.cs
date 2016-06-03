namespace UserVoiceSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Idea : BaseModel<int>
    {
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;

        public Idea()
        {
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
        }

        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string Title { get; set; }

        [Required]
        [MaxLength(10000)]
        [MinLength(2)]
        public string Description { get; set; }

        [Required]
        [MaxLength(16)]
        public string AuthorIp { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }
    }
}
