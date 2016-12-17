namespace E03_C_Sharp_Bunnies
{
    using System;
    using System.Text;
    using Contracts;
    using Extensions;

    [Serializable]
    public class Bunny
    {
        private const int BuilderSize = 200;

        public Bunny(string name, int age, FurType furType)
        {
            this.Name = name;
            this.Age = age;
            this.FurType = furType;
        }

        public int Age { get; private set; }

        public string Name { get; private set; }

        public FurType FurType { get; private set; }

        public void Introduce(IWriter writer)
        {
            writer.WriteLine($"{this.Name} - \"I am {this.Age} years old !\"");

            writer.WriteLine($"{this.Name} - \"And I am {this.FurType.ToString().SplitToSeparateWordsByUppercaseLetter()}");
        }

        public override string ToString()
        {
            var builder = new StringBuilder(BuilderSize);

            builder.AppendLine($"Bunny name: {this.Name}");
            builder.AppendLine($"Bunny age: {this.Age}");
            builder.AppendLine($"Bunny fur: {this.FurType.ToString().SplitToSeparateWordsByUppercaseLetter()}");

            return builder.ToString();
        }
    }
}
