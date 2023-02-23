
using GPACalculator.API.Features.Students.CalculateGPA;

namespace GpaCalculatorTests
{
    public class GpaCalculatorTests
    {
        [Test]
        public void Calculate_should_return_zero_gpa_when_grades_list_is_empty()
        {
            var calculator = new GPACalculator.API.Features.Students.CalculateGPA.GPACalculator();
            var gpa = calculator.Calculate(new List<StudentGrade>());

            Assert.AreEqual(0, gpa);
        }

        [Test]
        public void GpaCalculator_should_return_4_when_all_scores_are_100()
        {
            var calculator = new GPACalculator.API.Features.Students.CalculateGPA.GPACalculator();

            var studentGrades = new List<StudentGrade>();
            studentGrades.Add(new StudentGrade
            {
                StudentId = 1,
                Score = 100,
                SubjectCredits = 5
            });
            studentGrades.Add(new StudentGrade
            {
                StudentId = 1,
                Score = 100,
                SubjectCredits = 10
            });

            var gpa = calculator.Calculate(studentGrades);

            Assert.AreEqual(4.0, gpa);
        }
    }
}