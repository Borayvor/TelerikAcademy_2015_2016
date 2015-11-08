namespace E02_AllArticlesInPriceRange
{
    using System;
    using System.Linq;
    using System.Text;

    using Wintellect.PowerCollections;

    public class StartUp
    {
        private static OrderedMultiDictionary<decimal, Article> orderByPrice =
            new OrderedMultiDictionary<decimal, Article>(true);

        public static void Main(string[] args)
        {
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));

            var output = new StringBuilder();

            for (string line = null; (line = Console.ReadLine()) != "End";)
            {
                var match = line.Split(new[] { ' ' }, 2);
                var name = match[0];
                var parameters = match[1].Split(';');
                string result = null;

                switch (name)
                {
                    case "AddProduct":
                        {
                            result = AddProduct(
                                name: parameters[0],
                                price: decimal.Parse(parameters[1]),
                                vendor: parameters[2]);
                            break;
                        }

                    case "FindProductsByPriceRange":
                        {
                            result = FindProductsByPriceRange(
                                min: decimal.Parse(parameters[0]),
                                max: decimal.Parse(parameters[1]));
                            break;
                        }

                    default:
                        {
                            throw new ArgumentException("Invalid command: " + name);
                        }
                }

                output.AppendLine(line);
                output.AppendLine(result);
                output.AppendLine();
            }

            Console.Write(output);
        }

        private static string FindProductsByPriceRange(decimal min, decimal max)
        {
            var result = orderByPrice
                .Range(min, true, max, true)
                .Values.OrderBy(p => p.Price);

            if (!result.Any())
            {
                return "No products found !";
            }

            return string.Join(Environment.NewLine, result);
        }

        private static string AddProduct(string name, decimal price, string vendor)
        {
            var product = new Article(name, price, vendor);
            orderByPrice[price].Add(product);

            return "Product added !";
        }
    }
}
