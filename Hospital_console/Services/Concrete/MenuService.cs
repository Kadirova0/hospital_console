using System;
using ConsoleTables;
using Hospital_console.Data.Enums;



namespace Hospital_Console.Services.Concrete
{
    public class MenuService
    {
        private static HospitalService hospitalService = new();

        public static void MenuShowDoctors()
        {
            try
            {
                var doctors = hospitalService.GetDoctors();

                if (doctors.Count == 0)
                {
                    Console.WriteLine("There are no doctors!");
                    return;
                }

                var table = new ConsoleTable("Id", "Name", "Surname", "Price", "Department");

                foreach (var doctor in doctors)
                {
                    table.AddRow(doctor.Id, doctor.Name, doctor.Surname, doctor.PricePerSession, doctor.Department);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuAddDoctor()
        {
            try
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter surname:");
                string surname = Console.ReadLine();

                Console.WriteLine("Enter department:");
                Departments department = (Departments)Enum.Parse(typeof(Departments), Console.ReadLine(), true);

                Console.WriteLine("Enter price per session:");
                decimal pricePerSession = decimal.Parse(Console.ReadLine());

                int newId = hospitalService.AddDoctor(name, surname, pricePerSession, department);

                Console.WriteLine($"Doctor with ID {newId} was created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuDeleteDoctor()
        {
            try
            {
                Console.WriteLine("Enter doctor's ID:");
                int id = int.Parse(Console.ReadLine());

                hospitalService.DeleteDoctor(id);

                Console.WriteLine("Doctor deleted successfuly!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuShowPatients()
        {
            try
            {
                var patients = hospitalService.GetPatients();

                if (patients.Count == 0)
                {
                    Console.WriteLine("There are no patients!");
                    return;
                }

                var table = new ConsoleTable("Id", "Name", "Surname", "Phone");

                foreach (var patient in patients)
                {
                    table.AddRow(patient.Id, patient.Name, patient.Surname, patient.Phone);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuAddPatient()
        {
            try
            {
                Console.WriteLine("Enter name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter surname:");
                string surname = Console.ReadLine();

                Console.WriteLine("Enter phone:");
                string phone = Console.ReadLine();

                int newId = hospitalService.AddPatient(name, surname, phone);

                Console.WriteLine($"Patient with ID {newId} was created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuDeletePatient()
        {
            try
            {
                Console.WriteLine("Enter patient's ID:");
                int id = int.Parse(Console.ReadLine());

                hospitalService.DeletePatient(id);

                Console.WriteLine("Patient deleted successfuly!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuShowMeetings()
        {
            try
            {
                var meetings = hospitalService.GetMeetings();

                if (meetings.Count == 0)
                {
                    Console.WriteLine("There are no meetings!");
                    return;
                }

                var table = new ConsoleTable("Id", "Doctor", "Patient", "Reason", "Date");

                foreach (var meeting in meetings)
                {
                    table.AddRow(meeting.Id, meeting.Doctor.Name, meeting.Patient.Name, meeting.Reason, meeting.Date.ToString("dd/MM/yyyy"));
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuAddMeeting()
        {
            try
            {
                Console.WriteLine("Enter patient's ID:");
                int patientId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter doctor's ID:");
                int doctorId = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter reason:");
                string reason = Console.ReadLine();

                Console.WriteLine("Enter date (dd/MM/yyyy):");
                DateTime date = DateTime.Parse(Console.ReadLine());

                int newId = hospitalService.AddMeeting(patientId, doctorId, date, reason);

                Console.WriteLine($"Meeting with ID {newId} was created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }

        public static void MenuDeleteMeeting()
        {
            try
            {
                Console.WriteLine("Enter meetings's ID:");
                int id = int.Parse(Console.ReadLine());

                hospitalService.DeleteMeeting(id);

                Console.WriteLine("Meeting deleted successfuly!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }

        }

        public static void MenuShowReport()
        {
            try
            {
                Console.WriteLine("Enter start date (dd/MM/yyyy):");
                DateTime startDate = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter end date (dd/MM/yyyy):");
                DateTime endDate = DateTime.Parse(Console.ReadLine());

                var report = hospitalService.GetReport(startDate, endDate);

                Console.WriteLine($"Meeting count: {report.MeetingCount} | Income: {report.Income}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, got an error: {ex.Message}");
            }
        }
    }
}
