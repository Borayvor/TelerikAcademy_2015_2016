namespace E02_ProductsInPriceRange
{
    using System;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;
    using Product = System.Tuple<string, decimal>;

    public class StartUp
    {
        private static OrderedMultiDictionary<decimal, Product> orderByPrice =
                                new OrderedMultiDictionary<decimal, Product>(true);

        public static string FindProductsByPriceRange(decimal min, decimal max)
        {
            var result = orderByPrice
                .Range(min, true, max, true)
                .Values.OrderBy(p => p.Item2);

            if (!result.Any())
            {
                return "No products found !";
            }

            return string.Join(Environment.NewLine, result);
        }

        public static string AddProduct(string name, decimal price)
        {
            var product = new Product(name, price);

            orderByPrice[price].Add(product);

            return "Product added !";
        }

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
                                price: decimal.Parse(parameters[1]));
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
    }
}
