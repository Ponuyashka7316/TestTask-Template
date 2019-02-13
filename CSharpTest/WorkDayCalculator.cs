using System;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        /// <summary>
        /// Calculating work days
        /// </summary>
        /// <param name="startDate">date of commencement of work</param>
        /// <param name="dayCount">count of work days</param>
        /// <param name="weekEnds">array of weekend periods</param>
        /// <returns></returns>
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            DateTime resultDate = startDate;
            int workDaysCounter = dayCount - 1;
            while (workDaysCounter != 0)
            {
                if (weekEnds != null)
                    for (int i = 0; i < weekEnds.Length; i++)
                        if (weekEnds[i].StartDate > weekEnds[i].EndDate)
                            throw new ArgumentException();
                        else if (resultDate.InRange(weekEnds[i].StartDate, weekEnds[i].EndDate))
                        {
                            ++workDaysCounter;
                            break;
                        }
                resultDate = resultDate.AddDays(1);
                --workDaysCounter;
            }
            return resultDate;
        }
    }
}
