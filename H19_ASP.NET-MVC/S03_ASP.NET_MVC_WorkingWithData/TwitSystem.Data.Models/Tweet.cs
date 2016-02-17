namespace TwitSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        private ICollection<Tag> tags;

        public Tweet()
        {
            this.tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(260)]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
