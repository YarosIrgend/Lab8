using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab8
{
    public class Hospital : IChangeable
    {
        private List<Doctor> _doctorsList = new List<Doctor>();
        private List<Patient> _patientsList = new List<Patient>();

        public List<Doctor> DoctorsList
        {
            get => _doctorsList;
        }

        public List<Patient> PatientsList
        {
            get => _patientsList;
        }
        
        public Hospital()
        {
            _doctorsList.Add(new Doctor("Микола", "Соколов", new Schedule("10:00", "15:00"), "Кардіолог"));
            _doctorsList.Add(new Doctor("Олександр", "Богомолець", new Schedule("11:30", "16:00"), "Онколог"));
            _doctorsList.Add(new Doctor("П'єр", "Фошар", new Schedule("09:00", "12:30"), "Стоматолог"));
            _doctorsList.Add(new Doctor("Сергій", "Риков", new Schedule("10:00", "13:00"), "Офтальмолог"));
            _doctorsList.Add(new Doctor("Тарік", "Акар", new Schedule("11:00", "16:00"), "Гастроентеролог"));
        }

        public void AddDoctor()
        {
            Console.Write("Введіть ім'я: ");
            string name = Console.ReadLine();
            Console.Write("Введіть прізвище: ");
            string surname = Console.ReadLine();
            Console.Write("Введіть початок роботи (від 09:00 до 15:30): ");
            string workStart = Console.ReadLine();
            Console.Write("Введіть кінець роботи (від 09:30 до 16:00): ");
            string workEnd = Console.ReadLine();
            Schedule schedule = new Schedule(workStart, workEnd);
            Console.Write("Введіть спеціальність: ");
            string speciality = Console.ReadLine();
            _doctorsList.Add(new Doctor(name, surname, schedule, speciality));
            Console.WriteLine("Додано");
            Thread.Sleep(1000);
        }

        public void DeleteDoctor()
        {
            Doctor doctor = DoctorSearch();
            if (doctor != null)
            {
                _doctorsList.Remove(doctor);
                Console.WriteLine("Видалено");
                Thread.Sleep(1000);
            }
        }

        public void ChangeDoctorData()
        {
            Console.Clear();
            Doctor doctor = DoctorSearch();
            if (doctor == null)
            {
                return;
            }
            doctor.ChangeData();
        }

        public void AddPatient()
        {
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
            _patientsList.Add(new Patient(name, surname));
        }

        public void DeletePatient()
        {
            return;
        }
        
        public void PatientSearch()
        {
            Console.Clear();
            Console.Write("Введіть прізвище: ");
            string surname = Console.ReadLine();
            Console.Write("Введіть ім'я: ");
            string name = Console.ReadLine();
            foreach (Patient patient in _patientsList)
            {
                if (patient.Surname == surname && patient.Name == name)
                {
                    Console.WriteLine($"Прізвище - {surname}");
                    Console.WriteLine($"Ім'я - {name}");
                    Console.WriteLine("\nЗаписи:\n");
                    patient.MedicalCard.Read();
                } 
            }
        }

        public Doctor DoctorSearch()
        {
            Console.Write("Введіть прізвище: ");
            string surname = Console.ReadLine();
            foreach (var doctor in _doctorsList)
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
            foreach (var doctor in _doctorsList)
            {
                Console.WriteLine($"Прізвище - {doctor.Surname}");
                Console.WriteLine($"Ім'я - {doctor.Name}");
                Console.WriteLine(
                    $"Початок роботи - {doctor.Schedule.WorkStart}, кінець роботи - {doctor.Schedule.WorkEnd}");
                Console.WriteLine($"Спеціальність - {doctor.Speciality}\n");
            }
        }

        public List<Doctor> GetDoctorsList() => _doctorsList;

        public void CheckDoctor()
        {
            Console.Write("Введіть спеціальність: ");
            string speciality = Console.ReadLine();
            Doctor doctor = null;
            foreach (Doctor doc in GetDoctorsList())
            {
                if (doc.Speciality == speciality)
                {
                    doctor = doc;
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

            if (doctor == null)
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