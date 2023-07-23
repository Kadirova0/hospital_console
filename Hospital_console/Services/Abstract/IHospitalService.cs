using Hospital_console.Data.Enums;
using Hospital_console.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_console.Services.Abstract
{
   public interface IHospitalService
    {
        public List<Doctor> GetDoctors();
        public int AddDoctor(string name, string surname, decimal pricePerSession, Departments department );
        public void DeleteDoctor( int id );

        public List<Patient> GetPatients();
        public int AddPatient(string name, string surname, string phone);
        public void DeletePatient( int id );

        public List<Meeting> GetMeetings();
        public int AddMeeting (int doctor, int patient, DateTime data, string reason );
        public void DeleteMeeting( int id );
        public Report GetReport(DateTime minDate, DateTime maxDate);
    }
}
