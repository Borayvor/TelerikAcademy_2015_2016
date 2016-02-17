namespace TwitSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tag
    {
        private ICollection<Tweet> tweets;

        public Tag()
        {
            this.tweets = new HashSet<Tweet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(2)]
        [MaxLength(100)]
        [RegularExpression(@"[#]\w+",
         ErrorMessage = "Must start with '#' and contains only alphanumeric and underscore !")]
        public string Name { get; set; }

        public virtual ICollection<Tweet> Tweets
        {
            get { return this.tweets; }
            set { this.tweets = value; }
        }
    }
}
