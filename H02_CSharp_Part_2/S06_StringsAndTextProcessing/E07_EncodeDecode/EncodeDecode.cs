namespace E07_EncodeDecode
{
    using System;
    using System.Text;

    public class EncodeDecode
    {
        public static void Main(string[] args)
        {
            // Write a program that encodes and decodes a 
            // string using given encryption key (cipher).
            // The key consists of a sequence of characters.
            // The encoding/decoding is done by performing XOR 
            // (exclusive or) operation over the first letter of
            // the string with the first of the key, the 
            // second – with the second, etc. When the last key 
            // character is reached, the next is the first.

            Console.OutputEncoding = Encoding.Unicode; 

            string text = "Write a program that encodes and decodes a string using given encryption key (cipher). The key " +
                        "consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) " +
                        "operation over the first letter of the string with the first of the key, the second – with the second, " +
                        "etc. When the last key character is reached, the next is the first.";

            Console.WriteLine(text);

            string key = "cipherOrPassword";

            string resultText = EncodingOrDecoding(text, key);

            Console.WriteLine(resultText);
            Console.WriteLine(EncodingOrDecoding(resultText, key));
        }


        private static string EncodingOrDecoding(string text, string key)
        {
            StringBuilder newText = new StringBuilder();

            for (int index = 0; index < text.Length; index++)
            {
                newText.Append((char)(text[index] ^ key[index % key.Length]));
            }

            return newText.ToString();
        }
    }
}
