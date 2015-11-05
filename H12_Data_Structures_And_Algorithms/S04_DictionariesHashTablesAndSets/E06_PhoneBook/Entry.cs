namespace E06_PhoneBook
{
    public class Entry
    {
        public const string Separator = " | ";

        public Entry(string name, string town, string phone)
        {
            this.Name = name;
            this.Town = town;
            this.Phone = phone;
        }

        public string Name { get; private set; }
        public string Town { get; private set; }
        public string Phone { get; private set; }

        public override string ToString()
        {
            return string.Join(Entry.Separator, this.Name, this.Town, this.Phone);
        }
    }
}
