namespace SchoolSystem.Common
{
    using System;
    using System.Text.RegularExpressions;

    public class Validator
    {
        public static void ValidateIsStringNullOrWhiteSpace(string value, string objectName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(objectName + "[ " + value + " ] " + ExceptionMessages.StringNullEmptyWhiteSpace);
            }
        }

        public static void ValidateNameLength(string value, string objectName)
        {
            if (value.Length < GlobalConstants.NameMinLength || value.Length > GlobalConstants.NameMaxLength)
            {
                throw new ArgumentOutOfRangeException(objectName + "[ " + value + " ] " + ExceptionMessages.StringLength);
            }
        }

        public static void ValidateNameCharacters(string value, string objectName)
        {
            string pattern = @"[^a-z^A-Z]+";
            var regEx = new Regex(pattern);

            var isNotValid = regEx.IsMatch(value);

            if (isNotValid)
            {
                throw new ArgumentException(objectName + "[ " + value + " ] " + ExceptionMessages.LatinAlphabet);
            }
        }

        public static void ValidateStidentMarksCount(int value)
        {
            if (value > GlobalConstants.StudentMarksMaxCount)
            {
                throw new ArgumentOutOfRangeException(ExceptionMessages.StidentMarksCountOutOfRange);
            }
        }

        public static void ValidateGradeValue(int value)
        {
            if (value < GlobalConstants.GradeMinValue || value > GlobalConstants.GradeMaxValue)
            {
                throw new ArgumentOutOfRangeException(ExceptionMessages.GradeValueOutOfRange);
            }
        }

        public static void ValidateMarkValue(float value)
        {
            if (value < GlobalConstants.MarksMinValue || value > GlobalConstants.MarksMaxValue)
            {
                throw new ArgumentOutOfRangeException(ExceptionMessages.MarkValueOutOfRange);
            }
        }
    }
}
