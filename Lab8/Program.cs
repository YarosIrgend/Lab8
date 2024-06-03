using System;
using System.Text;

namespace Lab8
{
    enum UserChoices
    {
        Exit,
        Doctor,
        Patient
    }

    enum DoctorChoices
    {
        Exit,
        AddDoctor,
        DeleteDoctor,
        ChangeDoctorData,
        CheckDoctors,
        CheckDoctor
    }

    enum PatientChoices
    {
        Exit,
        AddPatient,
        SearchPatient,
        EditPatientMedicalCard,
    }

    internal class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Hospital hospital = new Hospital();
            int userChoice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Вітаю в інформаційній системі лікарні :)");
                Console.WriteLine("Кого дані змінити?");
                Console.WriteLine("1 - лікаря");
                Console.WriteLine("2 - пацієнта");
                Console.WriteLine("0 - вийти");
                bool isChoiceValid = false;
                while (!isChoiceValid)
                {
                    try
                    {
                        userChoice = int.Parse(Console.ReadLine());
                        isChoiceValid = true;
                    }
                    catch
                    {
                        Console.WriteLine("Перевведіть дані");
                    }
                }

                if (userChoice == (int)UserChoices.Doctor)
                {
                    UsingDoctorInterface(hospital);
                }
                else if (userChoice == (int)UserChoices.Patient)
                {
                    UsingPatientInterface(hospital);
                }
            } while (userChoice != (int)UserChoices.Exit);
        }

        private static void UsingDoctorInterface(Hospital hospital)
        {
            int userChoice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - додати лікаря");
                Console.WriteLine("2 - видалити лікаря");
                Console.WriteLine("3 - змінити дані про лікаря");
                Console.WriteLine("4 - подивитися лікарів");
                Console.WriteLine("5 - знайти лікаря за спеціальністю");
                Console.WriteLine("0 - вийти");
                bool isChoiceValid = false;
                while (!isChoiceValid)
                {
                    try
                    {
                        userChoice = int.Parse(Console.ReadLine());
                        isChoiceValid = true;
                    }
                    catch
                    {
                        Console.WriteLine("Перевведіть дані");
                    }
                }

                switch (userChoice)
                {
                    case (int)DoctorChoices.AddDoctor:
                        Console.Clear();
                        hospital.AddDoctor();
                        break;

                    case (int)DoctorChoices.DeleteDoctor:
                        Console.Clear();
                        hospital.DeleteDoctor();
                        break;

                    case (int)DoctorChoices.ChangeDoctorData:
                        Console.Clear();
                        hospital.ChangeDoctorData();
                        break;

                    case (int)DoctorChoices.CheckDoctors:
                        Console.Clear();
                        hospital.DoctorsListPrint();
                        Console.WriteLine("Натисніть Enter, щоб закрити");
                        Console.Read();
                        break;

                    case (int)DoctorChoices.CheckDoctor:
                        Console.Clear();
                        hospital.CheckDoctor();
                        break;
                }
            } while (userChoice != (int)DoctorChoices.Exit);
        }

        private static void UsingPatientInterface(Hospital hospital)
        {
            int userChoice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - додати пацієнта");
                Console.WriteLine("2 - знайти пацієнта");
                Console.WriteLine("3 - записати дані в мед. карту");
                Console.WriteLine("0 - вийти");
                bool isChoiceValid = false;
                while (!isChoiceValid)
                {
                    try
                    {
                        userChoice = int.Parse(Console.ReadLine());
                        isChoiceValid = true;
                    }
                    catch
                    {
                        Console.WriteLine("Перевведіть дані");
                    }
                }

                switch (userChoice)
                {
                    case (int)PatientChoices.AddPatient:
                        hospital.AddPatient();
                        break;
                    
                    case (int)PatientChoices.SearchPatient:
                        hospital.PatientSearch();
                        break;
                    
                    case (int)PatientChoices.EditPatientMedicalCard:
                        Doctor doctor = hospital.DoctorSearch();
                        doctor.ChangePatientData();
                        break;
                }
            } while (userChoice != (int)PatientChoices.Exit);
        }
    }
}