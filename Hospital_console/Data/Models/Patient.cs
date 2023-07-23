using System;
using Hospital_console.Data.Common;

namespace Hospital_Console.Data.Models
{
    public class Patient : BaseEntity
    {
        private static int count = 0;

        public Patient(string name, string surname, string phone)
        {
            Name = name;
            Surname = surname;
            Phone = phone;

            Id = count;
            count++;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
    }
}