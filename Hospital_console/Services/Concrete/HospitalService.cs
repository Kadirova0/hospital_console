using System;
using Hospital_console.Data.Enums;
using Hospital_console.Data.Models;
using Hospital_console.Services.Abstract;
using Hospital_Console.Data.Enums;
using Hospital_Console.Data.Models;
using Hospital_Console.Services.Abstract;

namespace Hospital_Console.Services.Concrete
{
    public class HospitalService : IHospitalService
    {
        private List<Doctor> doctors;
        private List<Meeting> meetings;
        private List<Patient> patients;

        public HospitalService()
        {
            doctors = new();
            meetings = new();
            patients = new();
        }

        public int AddDoctor(string name, string surname, decimal pricePerSession, Departments department)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name is null!");
            if (string.IsNullOrWhiteSpace(surname)) throw new Exception("Surname is null!");
            if (pricePerSession < 0) throw new Exception("Price is negative!");

            var doctor = new Doctor(name, surname, pricePerSession, department);

            doctors.Add(doctor);

            return doctor.Id;
        }

        public int AddMeeting(int patientId, int doctorId, DateTime date, string reason)
        {
            if (patientId < 0) throw new Exception("Patient Id is negative!");
            if (doctorId < 0) throw new Exception("Doctor Id is negative!");
            if (string.IsNullOrWhiteSpace(reason)) throw new Exception("Reason is null!");
            if (date <= DateTime.Now) throw new Exception("Date is earlier than now!");

            var foundPatient = patients.FirstOrDefault(x => x.Id == patientId);
            if (foundPatient is null) throw new Exception("Patient is not found!");

            var foundDoctor = doctors.FirstOrDefault(x => x.Id == doctorId);
            if (foundDoctor is null) throw new Exception("Doctor is not found!");

            var meeting = new Meeting(foundDoctor, foundPatient, date, reason);

            meetings.Add(meeting);

            return meeting.Id;
        }

        public int AddPatient(string name, string surname, string phone)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name is null!");
            if (string.IsNullOrWhiteSpace(surname)) throw new Exception("Surname is null!");
            if (string.IsNullOrWhiteSpace(phone)) throw new Exception("Phone is null!");

            var patient = new Patient(name, surname, phone);

            patients.Add(patient);

            return patient.Id;
        }

        public void DeleteDoctor(int id)
        {
            if (id < 0) throw new Exception("Id is negative!");

            int doctorIndex = doctors.FindIndex(x => x.Id == id);

            if (doctorIndex == -1) throw new Exception("Doctor not found!");

            doctors.RemoveAt(doctorIndex);
        }

        public void DeleteMeeting(int id)
        {
            if (id < 0) throw new Exception("Id is negative!");

            int meetingIndex = meetings.FindIndex(x => x.Id == id);

            if (meetingIndex == -1) throw new Exception("Meeting not found!");

            meetings.RemoveAt(meetingIndex);
        }

        public void DeletePatient(int id)
        {
            if (id < 0) throw new Exception("Id is negative!");

            int patientIndex = patients.FindIndex(x => x.Id == id);

            if (patientIndex == -1) throw new Exception("Patient not found!");

            patients.RemoveAt(patientIndex);
        }

        public List<Doctor> GetDoctors()
        {
            return doctors;
        }

        public List<Meeting> GetMeetings()
        {
            return meetings;
        }

        public List<Patient> GetPatients()
        {
            return patients;
        }

        public Report GetReport(DateTime minDate, DateTime maxDate)
        {
            if (minDate > maxDate) throw new Exception("Min date is grater than last date!");

            var result = meetings.Where(x => x.Date >= minDate && x.Date <= maxDate).ToList();

            int meetingCount = result.Count;
            decimal income = result.Sum(x => x.Doctor.PricePerSession);

            return new Report(meetingCount, income);
        }
    }
}
