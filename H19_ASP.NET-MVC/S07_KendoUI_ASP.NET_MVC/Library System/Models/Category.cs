namespace Library_System.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public Category()
        {
        }

        public virtual int Id { get; set; }

        [Required]
        public virtual string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}