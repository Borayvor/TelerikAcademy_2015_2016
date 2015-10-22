namespace E07_CuncurrentChanges
{
    using System.Linq;
    using E01_NorthwindDbContext;

    public class CuncurrentChanges
    {
        public static void Main(string[] args)
        {
            using (var db1 = new NorthwindEntities())
            {
                using (var db2 = new NorthwindEntities())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        db1.Categories.Add(new Category()
                        {
                            CategoryName = "NewCategory" + i
                        });

                        db2.Categories.Add(new Category()
                        {
                            CategoryName = "NewCategory" + i
                        });

                        db1.SaveChanges();
                        db2.SaveChanges();
                    }

                    //Editin same entry
                    var firstEntry = db1.Categories.First(x => x.CategoryName == "NewCategory0");
                    firstEntry.CategoryName = "Lol";

                    var sameEntry = db2.Categories.First(x => x.CategoryName == "NewCategory0");

                    db2.Categories.Remove(sameEntry);

                    //Removing an entry before editing it throws an exception
                    //db2.SaveChanges();
                    db1.SaveChanges();
                }
            }
        }
    }
}
