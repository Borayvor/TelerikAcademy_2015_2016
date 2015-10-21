namespace E09_MySQL_Library
{
    using System;
    using System.Text;

    internal class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime? PublishDate { get; set; }

        public string Isbn { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("   Book: " + this.Title);
            result.AppendLine("      - Author: " + this.Author);

            if (this.PublishDate != null)
            {
                result.AppendLine("      - Publish date: " + this.PublishDate.Value.ToShortDateString());
            }

            if (!string.IsNullOrEmpty(this.Isbn))
            {
                result.AppendLine("      - ISBN: " + this.Isbn);
            }

            return result.ToString();
        }
    }
}