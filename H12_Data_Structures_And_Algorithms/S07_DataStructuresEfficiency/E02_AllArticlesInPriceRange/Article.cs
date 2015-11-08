namespace E02_AllArticlesInPriceRange
{
    using System;

    public class Article : IComparable<Article>
    {
        public Article(string title, decimal price, string vendor)
        {
            this.Title = title;
            this.Price = price;
            this.Vendor = vendor;
        }

        public string Title { get; private set; }

        public decimal Price { get; private set; }

        public string Vendor { get; private set; }

        public int CompareTo(Article other)
        {
            return string.Compare(this.Title, other.Title);
        }

        public override string ToString()
        {
            return string.Join(
                "; ",
                "Price: " + this.Price,
                "Title: " + this.Title,
                "Vendor: " + this.Vendor);
        }
    }
}