using System;
using Hospital_console.Data.Common;

namespace Hospital_Console.Data.Models
{
    public class Meeting : BaseEntity
    {
        private static int count = 0;

        public Meeting(Doctor doctor, Patient patient, DateTime date, string reason)
        {
            Doctor = doctor;
            Patient = patient;
            Date = date;
            Reason = reason;

            Id = count;
            count++;
        }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
    }
}


