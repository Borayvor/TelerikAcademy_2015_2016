namespace E07_OneSystemToAnyOther
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Supported formats Hex, Bin and Dec.
    /// </summary>
    public static class NumberConverter
    {
        /// <summary>
        /// Convert from numeral system of given base baseFormat
        /// to other numeral system of base wantedBaseFormat 
        /// (2 ≤ baseFormat, wantedBaseFormat ≤ 16).
        /// </summary>
        /// <param name="number"></param>
        /// <param name="baseFormat"></param>
        /// <param name="wantedBaseFormat"></param>
        /// <returns>Return converted number as string.</returns>
        public static string Covert(string number, int baseFormat, int wantedBaseFormat)
        {
            string result = string.Empty;

            switch (baseFormat)
            {
                case (int)SupportedBaseFormat.Bin:
                    {
                        switch (wantedBaseFormat)
                        {
                            case (int)SupportedBaseFormat.Bin:
                                {
                                    result = BinaryToDecimal(number);
                                    break;
                                }
                            case (int)SupportedBaseFormat.Hex:
                                {
                                    result = BinaryToHexadecimal(number);
                                    break;
                                }
                            default:
                                {
                                    result = "This format is not supported !";
                                    break;
                                }
                        }

                        break;
                    }
                case (int)SupportedBaseFormat.Dec:
                    {
                        switch (wantedBaseFormat)
                        {
                            case (int)SupportedBaseFormat.Bin:
                                {
                                    result = DecimalToBinary(number);
                                    break;
                                }

                            case (int)SupportedBaseFormat.Hex:
                                {
                                    result = DecimalToHexadecimal(number);
                                    break;
                                }
                            default:
                                {
                                    result = "This format is not supported !";
                                    break;
                                }
                        }

                        break;
                    }
                case (int)SupportedBaseFormat.Hex:
                    {
                        switch (wantedBaseFormat)
                        {
                            case (int)SupportedBaseFormat.Dec:
                                {
                                    result = HexadecimalToDecimal(number);
                                    break;
                                }

                            case (int)SupportedBaseFormat.Bin:
                                {
                                    result = HexadecimalToBinary(number);
                                    break;
                                }
                            default:
                                {
                                    result = "This format is not supported !";
                                    break;
                                }
                        }

                        break;
                    }
                default:
                    {
                        result = "This format is not supported !";
                        break;
                    }
            }

            return result;
        }
                       
        private static string DecimalToBinary(string decimalNumberAsString)
        {
            const int decimalFormat = 64;
            const int baseFormat = 2;

            long decimalNumber = long.Parse(decimalNumberAsString);

            List<long> binaryNumber = new List<long>();

            if (decimalNumber >= 0)
            {
                // positive numbers
                while (decimalNumber != 0)
                {
                    binaryNumber.Add((decimalNumber % baseFormat));
                    decimalNumber /= baseFormat;
                }

                while ((binaryNumber.Count % decimalFormat != 0) || binaryNumber.Count == 0)
                {
                    binaryNumber.Add(0);
                }
            }
            else
            {
                // negative numbers
                while (decimalNumber != 0)
                {
                    binaryNumber.Add(((decimalNumber * (-1)) % baseFormat));
                    decimalNumber /= baseFormat;
                }

                while (binaryNumber.Count % decimalFormat != 0)
                {
                    binaryNumber.Add(1);
                }
            }

            StringBuilder result = new StringBuilder();

            for (int index = binaryNumber.Count - 1; index >= 0; index--)
            {
                result.Append(binaryNumber[index]);
            }

            return Convert.ToString(result);
        }

        private static string BinaryToDecimal(string binaryNumber)
        {
            const int decimalFormat = 64;

            long decimalNumber = 0;

            if (binaryNumber.Length <= decimalFormat)
            {
                for (int i = 0; i < binaryNumber.Length; i++)
                {
                    if (binaryNumber[i] != '1' && binaryNumber[i] != '0')
                    {
                        throw new ArgumentException("You must enter a binary number !");
                    }

                    decimalNumber = (decimalNumber << 1) + (binaryNumber[i] == '1' ? 1 : 0);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("The binary number is too big !");
            }

            return decimalNumber.ToString();
        }

        private static string DecimalToHexadecimal(string decimalNumberAsString)
        {
            const int baseFormat = 16;

            long decimalNumber = long.Parse(decimalNumberAsString);

            StringBuilder reversedHexNumber = new StringBuilder();

            while (decimalNumber > 0)
            {
                long remainder = decimalNumber % baseFormat;

                switch (remainder)
                {
                    case 10:
                        {
                            reversedHexNumber.Append('A');
                            break;
                        }
                    case 11:
                        {
                            reversedHexNumber.Append('B');
                            break;
                        }
                    case 12:
                        {
                            reversedHexNumber.Append('C');
                            break;
                        }
                    case 13:
                        {
                            reversedHexNumber.Append('D');
                            break;
                        }
                    case 14:
                        {
                            reversedHexNumber.Append('E');
                            break;
                        }
                    case 15:
                        {
                            reversedHexNumber.Append('F');
                            break;
                        }
                    default:
                        {
                            reversedHexNumber.Append(remainder);
                            break;
                        }
                }

                decimalNumber /= baseFormat;
            }

            StringBuilder hexNumber = new StringBuilder();

            for (int i = reversedHexNumber.Length - 1; i >= 0; i--)
            {
                hexNumber.Append(reversedHexNumber[i]);
            }

            return hexNumber.ToString();
        }

        private static string HexadecimalToDecimal(string hex)
        {
            const int baseFormat = 16;

            long decimalNumber = 0;
            long power = 1;

            for (int index = hex.Length - 1; index >= 0; index--)
            {
                int digit;

                switch (hex[index])
                {
                    case 'A':
                        {
                            digit = 10;
                            break;
                        }
                    case 'B':
                        {
                            digit = 11;
                            break;
                        }
                    case 'C':
                        {
                            digit = 12;
                            break;
                        }
                    case 'D':
                        {
                            digit = 13;
                            break;
                        }
                    case 'E':
                        {
                            digit = 14;
                            break;
                        }
                    case 'F':
                        {
                            digit = 15;
                            break;
                        }
                    default:
                        {
                            digit = hex[index] - '0';

                            if (digit < 0 || digit > 9)
                            {
                                throw new ArgumentException("You must enter " +
                                    "a hexadecimal number !");
                            }
                            break;
                        }
                }

                decimalNumber += digit * power;
                power *= baseFormat;
            }

            return decimalNumber.ToString();
        }

        private static string HexadecimalToBinary(string hexadecimalNumber)
        {
            StringBuilder binaryNumber = new StringBuilder();

            for (int i = 0; i < hexadecimalNumber.Length; i++)
            {
                switch (hexadecimalNumber[i])
                {
                    case '0':
                        {
                            binaryNumber.Append("0000");
                            break;
                        }
                    case '1':
                        {
                            binaryNumber.Append("0001");
                            break;
                        }
                    case '2':
                        {
                            binaryNumber.Append("0010");
                            break;
                        }
                    case '3':
                        {
                            binaryNumber.Append("0011");
                            break;
                        }
                    case '4':
                        {
                            binaryNumber.Append("0100");
                            break;
                        }
                    case '5':
                        {
                            binaryNumber.Append("0101");
                            break;
                        }
                    case '6':
                        {
                            binaryNumber.Append("0110");
                            break;
                        }
                    case '7':
                        {
                            binaryNumber.Append("0111");
                            break;
                        }
                    case '8':
                        {
                            binaryNumber.Append("1000");
                            break;
                        }
                    case '9':
                        {
                            binaryNumber.Append("1001");
                            break;
                        }
                    case 'A':
                        {
                            binaryNumber.Append("1010");
                            break;
                        }
                    case 'B':
                        {
                            binaryNumber.Append("1011");
                            break;
                        }
                    case 'C':
                        {
                            binaryNumber.Append("1100");
                            break;
                        }
                    case 'D':
                        {
                            binaryNumber.Append("1101");
                            break;
                        }
                    case 'E':
                        {
                            binaryNumber.Append("1110");
                            break;
                        }
                    case 'F':
                        {
                            binaryNumber.Append("1111");
                            break;
                        }
                    default:
                        {
                            binaryNumber.Append("");
                            break;
                        }
                }
            }

            return binaryNumber.ToString();
        }

        private static string BinaryToHexadecimal(string binaryNumber)
        {
            StringBuilder hexadecimalNumber = new StringBuilder();

            for (int index = 0; index < binaryNumber.Length; index += 4)
            {
                switch (binaryNumber.Substring(index, 4))
                {
                    case "0000":
                        {
                            hexadecimalNumber.Append("0");
                            break;
                        }
                    case "0001":
                        {
                            hexadecimalNumber.Append("1");
                            break;
                        }
                    case "0010":
                        {
                            hexadecimalNumber.Append("2");
                            break;
                        }
                    case "0011":
                        {
                            hexadecimalNumber.Append("3");
                            break;
                        }
                    case "0100":
                        {
                            hexadecimalNumber.Append("4");
                            break;
                        }
                    case "0101":
                        {
                            hexadecimalNumber.Append("5");
                            break;
                        }
                    case "0110":
                        {
                            hexadecimalNumber.Append("6");
                            break;
                        }
                    case "0111":
                        {
                            hexadecimalNumber.Append("7");
                            break;
                        }
                    case "1000":
                        {
                            hexadecimalNumber.Append("8");
                            break;
                        }
                    case "1001":
                        {
                            hexadecimalNumber.Append("9");
                            break;
                        }
                    case "1010":
                        {
                            hexadecimalNumber.Append("A");
                            break;
                        }
                    case "1011":
                        {
                            hexadecimalNumber.Append("B");
                            break;
                        }
                    case "1100":
                        {
                            hexadecimalNumber.Append("C");
                            break;
                        }
                    case "1101":
                        {
                            hexadecimalNumber.Append("D");
                            break;
                        }
                    case "1110":
                        {
                            hexadecimalNumber.Append("E");
                            break;
                        }
                    case "1111":
                        {
                            hexadecimalNumber.Append("F");
                            break;
                        }
                }
            }

            return hexadecimalNumber.ToString();
        }
    }
}
