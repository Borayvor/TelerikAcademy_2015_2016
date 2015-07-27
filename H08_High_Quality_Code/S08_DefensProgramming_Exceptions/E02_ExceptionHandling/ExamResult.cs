using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if(value < 0)
            {
                throw new ArgumentException("The Grade cannot be negative !");
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if(value < 0)
            {
                throw new ArgumentException("The MinGrade cannot be negative !");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if(value < 0)
            {
                throw new ArgumentException("The MaxGrade cannot be negative !");
            }

            if(value <= this.MinGrade)
            {
                throw new ArgumentException("The MaxGrade cannot be smaller, or equal than the MinGrade !");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }

        private set
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("The Comments cannot be empty or null !");
            }

            this.comments = value;
        }
    }
}
