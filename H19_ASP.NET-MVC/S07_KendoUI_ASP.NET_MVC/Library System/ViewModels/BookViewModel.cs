namespace Library_System.ViewModels
{
    public class BookViewModel
    {
        public virtual int Id { get; set; }

        public virtual string Title { get; set; }

        public virtual string Author { get; set; }

        public virtual string ISBN { get; set; }

        public virtual string Website { get; set; }

        public virtual string Description { get; set; }

        public virtual string CategoryName { get; set; }
    }
}