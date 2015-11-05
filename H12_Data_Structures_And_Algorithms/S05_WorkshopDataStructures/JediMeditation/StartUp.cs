namespace JediMeditation
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();

            string[] allJedi = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            SortedDictionary<int, List<string>> sortedAllJedi =
                new SortedDictionary<int, List<string>>();

            int jediKey;

            foreach (var jedi in allJedi)
            {
                switch (jedi[0])
                {
                    case 'm':
                        {
                            jediKey = 0;
                            break;
                        }
                    case 'k':
                        {
                            jediKey = 1;
                            break;
                        }
                    default:
                        {
                            jediKey = 2;
                            break;
                        }
                }

                if (sortedAllJedi.ContainsKey(jediKey))
                {
                    sortedAllJedi[jediKey].Add(jedi);
                }
                else
                {
                    var newJedi = new List<string>();
                    newJedi.Add(jedi);

                    sortedAllJedi.Add(jediKey, newJedi);
                }
            }

            for (var i = 0; i < sortedAllJedi.Count; i++)
            {
                Console.Write(string.Join(" ", sortedAllJedi[i]));

                if (i + 1 < sortedAllJedi.Count)
                {
                    Console.Write(" ");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
