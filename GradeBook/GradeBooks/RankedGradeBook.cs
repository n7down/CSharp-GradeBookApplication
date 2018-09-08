using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("need more then 5 students");
            }
			var totalNumberOfStudents = Students.Count;
			var numberOfStudentsToDropLetterGrade = totalNumberOfStudents * .2;
            return 'F';
        }
    }
}
