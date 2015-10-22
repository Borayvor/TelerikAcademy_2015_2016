namespace E02_CreatingDAO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NorthwindDao.InsertNewCustomers("AAAAA", "Banana", "#$$%^%$#*&", "CEO",
                "33 San Antonio Sq.", "Moskow", "11111", "China", "007-001002003", "007-001002003");

            //NorthwindDao.ModifyCustomer("AAAAA", "BigBoss");

            //NorthwindDao.DeleteCustomer("AAAAA");
        }
    }
}
