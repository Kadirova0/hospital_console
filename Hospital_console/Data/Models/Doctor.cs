using System;
using Hospital_console.Data.Common;
using Hospital_console.Data.Enums;

namespace Hospital_Console.Data.Models
{
    public class Doctor : BaseEntity
    {
        private static int count = 0;

        public Doctor(string name, string surname, decimal pricePerSession, Departments department)
        {
            Name = name;
            Surname = surname;
            PricePerSession = pricePerSession;
            Department = department;

            Id = count;
            count++;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal PricePerSession { get; set; }
        public Departments Department { get; set; }
    }
}
