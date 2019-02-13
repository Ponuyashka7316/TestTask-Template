using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    [TestClass]
    public class WorkDayCalculatorTests
    {

        [TestMethod]
        public void TestNoWeekEnd()
        {
            DateTime startDate = new DateTime(2014, 12, 1);
            int count = 10;

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, null);

            Assert.AreEqual(startDate.AddDays(count - 1), result);
        }

        [TestMethod]
        public void TestNormalPath()
        {
            DateTime startDate = new DateTime(2017, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 28)));
        }

        [TestMethod]
        public void TestWeekendAfterEnd()
        {
            DateTime startDate = new DateTime(2017, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2017, 4, 23), new DateTime(2017, 4, 25)),
                new WeekEnd(new DateTime(2017, 4, 29), new DateTime(2017, 4, 29))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 28)));
        }

        [TestMethod]
        public void TestDoubleWeekends()
        {
            DateTime startDate = new DateTime(2017, 4, 1);
            int count = 10;
            WeekEnd[] weekends = new WeekEnd[2]
            {
                new WeekEnd(new DateTime(2017, 4, 2), new DateTime(2017, 4, 4)),
                new WeekEnd(new DateTime(2017, 4, 6), new DateTime(2017, 4, 7))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.IsTrue(result.Equals(new DateTime(2017, 4, 15)));
        }

        [TestMethod]
        public void TestCurrentDate()
        {
            DateTime startDate = DateTime.Now;
            int count = 12;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(DateTime.Now.AddDays(2), DateTime.Now.AddDays(3))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

            Assert.AreEqual(startDate.AddDays(count), result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIncorrectWeekends()
        {
            DateTime startDate = new DateTime(2017, 4, 21);
            int count = 5;
            WeekEnd[] weekends = new WeekEnd[1]
            {
                new WeekEnd(new DateTime(2017, 4, 25), new DateTime(2017, 4, 24))
            };

            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekends);

        }
    }
}
