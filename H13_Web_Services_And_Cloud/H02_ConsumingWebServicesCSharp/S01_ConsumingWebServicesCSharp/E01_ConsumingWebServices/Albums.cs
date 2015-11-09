namespace E01_ConsumingWebServices
{
    using System.Text;

    public class Albums
    {
        public int UserId { get; set; }

        public string Id { get; set; }

        public string Title { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("UserId : {0}", this.UserId));
            result.AppendLine(string.Format("Id : {0}", this.Id));
            result.Append(string.Format("Title : {0}", this.Title));

            return result.ToString();
        }
    }
}
