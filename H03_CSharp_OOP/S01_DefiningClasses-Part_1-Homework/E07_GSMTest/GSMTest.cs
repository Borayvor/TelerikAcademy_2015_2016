namespace E07_GSMTest
{    
    using System;

    using E01_MoblePhones;

    public class GSMTest
    {
        public static void Main(string[] args)
        {
            // 07. GSM test:
            // Write a class GSMTest to test the GSM class:
            // Create an array of few instances of the GSM class.
            // Display the information about the GSMs in the array.
            // Display the information about the static property IPhone4S.

            GSM[] mobilePhone = new GSM[3];

            for (int i = 0; i < mobilePhone.Length; i++)
            {
                mobilePhone[i] = new GSM("Lumia 720", "Nokia", 890m, "Pesho I. Petrov",
                    new Battery(72m, 6m, BatteryType.LiIon),
                    new Display(8.7, "16M"));
            }
            
            mobilePhone[0].Owner = "Ivan P. Ivanov";
            mobilePhone[0].Battery.BatteryType = BatteryType.NiCd;
            mobilePhone[0].Display.NumberOfColors = "32M";
            mobilePhone[0].Battery.HoursIdle = 20m;

            mobilePhone[1].Price = 690.9m;
            mobilePhone[1].Battery.BatteryType = BatteryType.LiPol;
            mobilePhone[1].Display.Size = 6.4;
            mobilePhone[1].Battery.HoursTalk = 12.5m;

            mobilePhone[2] = GSM.IPhone4S;

            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < mobilePhone.Length; i++)
            {
                Console.WriteLine(mobilePhone[i]);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green + i;
            }
        }
    }
}
