using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace Lab8
{
    public class Hospital : IChangeable
    {
        private readonly List<Patient> _patientsList = new List<Patient>();

        private List<Doctor> DoctorsList { get; } = new List<Doctor>();

        public List<Patient> PatientsList => _patientsList;

        public Hospital()
        {
            DoctorsList.Add(new Doctor("Микола", "Соколов", new Schedule("10:00", "15:00"), "Кардіолог", this));
            DoctorsList.Add(new Doctor("Олександр", "Богомолець", new Schedule("11:30", "16:00"), "Онколог", this));
            DoctorsList.Add(new Doctor("П'єр", "Фошар", new Schedule("09:00", "12:30"), "Стоматолог", this));
            DoctorsList.Add(new Doctor("Сергій", "Риков", new Schedule("10:00", "13:00"), "Офтальмолог", this));
            DoctorsList.Add(new Doctor("Тарік", "Акар", new Schedule("11:00", "16:00"), "Гастроентеролог", this));
        }

        public void AddDoctor()
        {
            Console.Write("Введіть прізвище: ");
            string surname = Console.ReadLine();
            Console.Write("Введіть ім'я: ");
            string name = Console.ReadLine();
            Console.Write("Введіть початок роботи (від 09:00 до 15:30): ");
            string workStart = Console.ReadLine();
            Console.Write("Введіть кінець роботи (від 09:30 до 16:00): ");
            string workEnd = Console.ReadLine();
            Schedule schedule = new Schedule(workStart, workEnd);
            Console.Write("Введіть спеціальність: ");
            string speciality = Console.ReadLine();
            DoctorsList.Add(new Doctor(name, surname, schedule, speciality, this));
            Console.WriteLine("Додано");
            Thread.Sleep(1000);
        }

        public void DeleteDoctor()
        {
            Doctor doctor = DoctorSearch();
            if (doctor != null)
            {
                DoctorsList.Remove(doctor);
                Console.WriteLine("Видалено");
                Thread.Sleep(1000);
            }
        }

        public void ChangeDoctorData()
        {
            Console.Clear();
            Doctor doctor = DoctorSearch();
            doctor?.ChangeData();
        }

        public void AddPatient()
        {
            Console.Clear();
            Console.Write("Введіть прізвище: ");
            string surname = Console.ReadLine();
            Console.Write("Введіть ім'я: ");
            string name = Console.ReadLine();
            Console.Write("Треба прив'язати до лікаря\n");
            Doctor doctor = DoctorSearch();
            if (doctor == null)
            {
                return;
            }

            Patient patient = new Patient(name, surname, doctor);
            _patientsList.Add(patient);
            doctor.PatientsList.Add(patient);
            Console.WriteLine("Додано");
            Thread.Sleep(1000);
        }
        
        public void PatientDataPrint()
        {
            Console.Clear();
            Console.Write("Введіть прізвище: ");
            string surname = Console.ReadLine();
            Console.Write("Введіть ім'я: ");
            string name = Console.ReadLine();
            bool isFound = false;
            foreach (Patient patient in _patientsList)
            {
                if (patient.Surname == surname && patient.Name == name)
                {
                    isFound = true;
                    Console.WriteLine($"Прізвище - {surname}");
                    Console.WriteLine($"Ім'я - {name}");
                    Console.WriteLine($"Лікар - {patient.Doctor.Surname}");
                    Console.WriteLine("\nЗаписи:\n");
                    patient.MedicalCard.Read();
                } 
            }

            if (isFound)
            {
                Console.WriteLine("Натисніть Enter, щоб закрити");
                Console.Read();
            }
            else
            {
                Console.WriteLine("Такого пацієнта нема");
                Thread.Sleep(1000);
            }
        }

        public Patient PatientSearch()
        {
            Console.Clear();
            Console.Write("Введіть прізвище: ");
            string surname = Console.ReadLine();
            Console.Write("Введіть ім'я: ");
            string name = Console.ReadLine();
            foreach (Patient patient in PatientsList)
            {
                if (patient.Surname == surname && patient.Name == name)
                {
                    return patient;
                }
            }
            Console.WriteLine("Такого пацієнта нема");
            Thread.Sleep(1000);
            return null;
        }
        
        public Doctor DoctorSearch()
        {
            Console.Write("Введіть прізвище лікаря: ");
            string surname = Console.ReadLine();
            foreach (var doctor in DoctorsList)
            {
                if (doctor.Surname == surname)
                {
                    return doctor;
                }
            }

            Console.WriteLine("Нема такого лікаря");
            Thread.Sleep(1000);
            return null;
        }

        public void DoctorsListPrint()
        {
            Console.OutputEncoding = Encoding.Default;
            Console.InputEncoding = Encoding.Default;
            foreach (var doctor in DoctorsList)
            {
                Console.WriteLine($"Прізвище - {doctor.Surname}");
                Console.WriteLine($"Ім'я - {doctor.Name}");
                Console.WriteLine(
                    $"Початок роботи - {doctor.Schedule.WorkStart}, кінець роботи - {doctor.Schedule.WorkEnd}");
                Console.WriteLine("Вільні записи");
                foreach (string time in doctor.Schedule.FreeSchedule)
                {
                    Console.Write($"{time}, ");
                }
                Console.WriteLine();
                Console.WriteLine($"Спеціальність - {doctor.Speciality}\n");
            }
        }

        public void CheckDoctor()
        {
            Console.Write("Введіть спеціальність: ");
            string speciality = Console.ReadLine();
            bool isDocFound = false;
            foreach (Doctor doc in DoctorsList)
            {
                if (doc.Speciality == speciality)
                {
                    isDocFound = true;
                    Console.WriteLine();
                    Console.WriteLine($"Прізвище - {doc.Surname}");
                    Console.WriteLine($"Ім'я - {doc.Name}");
                    Console.WriteLine(
                        $"Початок роботи - {doc.Schedule.WorkStart}, кінець роботи - {doc.Schedule.WorkEnd}");
                    Console.WriteLine("Вільні записи:");
                    foreach (string time in doc.Schedule.FreeSchedule)
                    {
                        Console.Write($"{time}, ");
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Спеціальність - {doc.Speciality}");
                }
            }

            if (!isDocFound)
            {
                Console.WriteLine();
                Console.WriteLine("Таких лікарів нема");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine();
                Console.Write("Натисніть Enter, щоб вийти");
                Console.Read();
            }
        }
    }
}