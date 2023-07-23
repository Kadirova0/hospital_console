using Hospital_Console.Services.Concrete;
using System.Linq.Expressions;

namespace Hospital_console
{
    public class Program
    {
        static void Main(string[] args)
        {
         Console.Clear();

         int option;

            do
            {
                Console.WriteLine("1. Show Doctor");
                Console.WriteLine("2. Add Doctor");
                Console.WriteLine("3. Delete Doctor");
                Console.WriteLine("4. Show Patients");
                Console.WriteLine("5. Add Patient");
                Console.WriteLine("6. Delete Patient");
                Console.WriteLine("7. Show Meetings");
                Console.WriteLine("8. Add Meeting");
                Console.WriteLine("9. Delete Meeting");
                Console.WriteLine("10. Show Report");
                Console.WriteLine("0. Exit");

                Console.WriteLine("-----------------");
                Console.WriteLine("Enter an option please: ");
                Console.WriteLine("-----------------");

                while(!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid option");
                    Console.WriteLine("Enter an option please: ");
                    Console.WriteLine("-----------------");
                }

                 switch (option)
                {
                    case 1:
                        MenuService.MenuShowDoctors();
                        break;
                    case 2:
                        MenuService.MenuAddDoctor();
                        break;
                    case 3:
                        MenuService.MenuDeleteDoctor();
                        break;
                     case 4:
                        MenuService.MenuShowPatients();
                        break;
                     case 5:
                        MenuService.MenuAddPatient();
                        break;
                     case 6:   
                        MenuService.MenuDeletePatient();
                        break;
                     case 7:
                        MenuService.MenuShowMeetings();
                        break;
                     case 8:
                         MenuService.MenuAddMeeting();
                        break;
                     case 9:
                        MenuService.MenuDeleteMeeting();
                        break;
                     case 10:
                        MenuService.MenuShowReport();
                        break;
                     case 0:
                        Console.WriteLine("GoodBye!");
                        break;
                     default:
                        Console.WriteLine("There is no such option!");
                        break;
                }

            } while (option != 0);
        }
    }
}