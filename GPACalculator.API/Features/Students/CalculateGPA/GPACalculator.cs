namespace GPACalculator.API.Features.Students.CalculateGPA
{
    public class GPACalculator
    {
        public double Calculate(List<StudentGrade> studentGrades)
        {
            if (studentGrades.Count == 0)
            {
                return 0.0;
            }
            var totalCredits = studentGrades.Sum(g => g.SubjectCredits);
            var gpaCredits = 0.0;
            foreach (var studentGrade in studentGrades)
            {
                var gp = CalculateGp(studentGrade.Score);
                gpaCredits += gp * studentGrade.SubjectCredits;
            }
            return gpaCredits / totalCredits;
        }

        private double CalculateGp(int score)
        {
            if (score < 50) return 0;
            if (score <= 60) return 0.5;
            if (score <= 70) return 1.0;
            if (score <= 80) return 2.0;
            if (score <= 90) return 3.0;
            return 4.0;
        }
    }
}
