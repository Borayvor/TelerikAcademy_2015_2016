namespace E01_ClassChefInCSharp
{
    using System;

    public class MainProgram
    {
        static void Main(string[] args)
        {
            const int ExpectedValue = 666;
            const int MinX = int.MinValue;            
            const int MinY = int.MinValue;
            const int MaxX = int.MaxValue;
            const int MaxY = int.MaxValue;

            Chef chef = new Chef();

            // Task 2. Refactor the following if statement:
            var potato = GetPotato();

            if (potato != null)
            {
                if (potato.IsRotten && !potato.IsPeeled)
                {
                    chef.Cook(potato);
                }
            }

            //////////
            int x = 0;
            int y = 0;
            bool inRange = ((MinX <= x && x <= MaxX) && (MinY <= y && y <= MaxY));
            bool shouldVisitCell = true;

            if (inRange && shouldVisitCell)
            {
                VisitCell();
            }


            // Task 3. Refactor the following loop: 
            
            int[] array = new int[100];

            for (int index = 0; index < array.Length; index++)
            {
                array[index] = index;

                if (index % 10 == 0)
                {
                    Console.WriteLine(array[index]);

                    if (array[index] == ExpectedValue)
                    {
                        Console.WriteLine("Value Found");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(array[index]);
                }
            }
            //////
        }


        private static Vegetable GetPotato()
        {
            return new Vegetable("potato", true, false);
        }

        private static Vegetable GetCarrot()
        {
            return new Vegetable("carrot", false, false);
        }

        private static void VisitCell()
        {
            Console.WriteLine("Do something !");
        }
    }
}
