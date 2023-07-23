using System;
using Hospital_console.Data.Common;

namespace Hospital_Console.Data.Models
{
    public class Report : BaseEntity
    {
        private static int count = 0;

        public Report(int meetingCount, decimal income)
        {
            MeetingCount = meetingCount;
            Income = income;

            Id = count;
            count++;
        }

        public int MeetingCount { get; set; }
        public decimal Income { get; set; }
    }
}