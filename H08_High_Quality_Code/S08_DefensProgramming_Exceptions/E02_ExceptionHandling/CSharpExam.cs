using System;

public class CSharpExam : Exam
{
    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if(value < 0)
            {
                throw new ArgumentException("The Score cannot be negative !");
            }

            if(value > 100)
            {
                throw new ArgumentOutOfRangeException("The Score value is out of range !");
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");       
    }
}
