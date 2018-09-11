using System;
using System.Linq;
using System.Collections.Generic;
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
		
			// list students by average grade in asending order
			List<double> averageGradeList = Students.OrderBy(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();	
			var numberOfStudents = 0;
			var letterGrade = 'A';
			var averageGradeLetterGradeDictionary = new Dictionary<double, char>();
			foreach(double grade in averageGradeList)
			{
				averageGradeLetterGradeDictionary.Add(grade, letterGrade);
				numberOfStudents++;
				if(numberOfStudents >= numberOfStudentsToDropLetterGrade)
				{
					numberOfStudents = 0;
					switch(letterGrade)
					{
						case 'A':
							letterGrade = 'B';
							break;
						case 'B':
							letterGrade = 'C';
							break;
						case 'C':
							letterGrade = 'D';
							break;
						case 'D':
							letterGrade = 'F';
							break;
						case 'F':
							break;
						default:
							break;
					}
				}
			}
			return averageGradeLetterGradeDictionary[averageGrade];
        }
    }
}
