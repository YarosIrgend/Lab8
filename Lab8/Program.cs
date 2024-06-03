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
        CheckDoctor,
        PassAppointment
    }

    enum PatientChoices
    {
        Exit,
        AddPatient,
        ShowPatientData,
        EditPatientMedicalCard,
        MakeAppointment
    }

    internal class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.Default;
            Console.InputEncoding = Encoding.Default;
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

                switch (userChoice)
                {
                    case (int)UserChoices.Doctor:
                        UsingDoctorInterface(hospital);
                        break;
                    case (int)UserChoices.Patient:
                        UsingPatientInterface(hospital);
                        break;
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
                Console.WriteLine("6 - провести обстеження пацієнту");
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
                    
                    case (int)DoctorChoices.PassAppointment:
                        Console.Clear();
                        Doctor doctor = hospital.DoctorSearch();
                        if (doctor == null)
                        {
                            return;
                        }
                        doctor.PassAppointment();
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
                Console.WriteLine("2 - подивитися пацієнта");
                Console.WriteLine("3 - записати дані в мед. карту");
                Console.WriteLine("4 - записатися на прийом");
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
                    
                    case (int)PatientChoices.ShowPatientData:
                        hospital.PatientDataPrint();
                        break;
                    
                    case (int)PatientChoices.EditPatientMedicalCard:
                        Console.Clear();
                        Doctor doctor = hospital.DoctorSearch();
                        if (doctor == null)
                        {
                            return;
                        }
                        doctor.ChangePatientData();
                        break;
                    
                    case (int)PatientChoices.MakeAppointment:
                        Patient patient = hospital.PatientSearch();
                        if (patient == null)
                        {
                            return;
                        }
                        patient.AddAppointment();
                        break;
                }
            } while (userChoice != (int)PatientChoices.Exit);
        }
    }
}