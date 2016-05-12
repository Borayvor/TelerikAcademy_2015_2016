﻿namespace Library_System.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual string Title { get; set; }

        [Required]
        public virtual string Author { get; set; }

        public virtual string ISBN { get; set; }

        public virtual string Website { get; set; }

        public virtual string Description { get; set; }

        public virtual Category Category { get; set; }
    }
}