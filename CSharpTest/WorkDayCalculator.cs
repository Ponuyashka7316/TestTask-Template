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
            while (workDaysCounter > 0)
            {
                //flag determines whether current day is a weekend or a working day 
                bool flag = false;
                if (weekEnds != null)
                {
                    for (int i = 0; i < weekEnds.Length; ++i)
                    {
                        if (weekEnds[i].StartDate > weekEnds[i].EndDate)
                            throw new ArgumentException();
                        if (resultDate.InRange(weekEnds[i].StartDate, weekEnds[i].EndDate))
                            flag = true;
                    }
                    if (flag == false)
                        --workDaysCounter;
                    resultDate = resultDate.AddDays(1);
                }
                else
                {
                    resultDate = resultDate.AddDays(1);
                    --workDaysCounter;
                }
            }
            return resultDate;
        }
    }
}
