using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab8
{
    public class Doctor : Human
    {
        public Hospital Hospital { get; }
        public Schedule Schedule { get; private set; }
        public string Speciality { get; private set; }
        
        public List<Patient> Patients = new List<Patient>();
        
        public Doctor(string name, string surname, Schedule schedule, string speciality)
        {
            Name = name;
            Surname = surname;
            Schedule = schedule;
            Speciality = speciality;
        }

        public void ChangeData()
        {
            Console.Write("Що хочете змінити?\n1 - Ім'я\n2 - Прізвище\n3 - Розклад\n4 - Спеціальність\n");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case (int)DoctorData.Name:
                    Console.Write("Введіть ім'я: ");
                    string name = Console.ReadLine();
                    Name = name;
                    break;
                
                case (int)DoctorData.Surname:
                    Console.Write("Введіть прізвище: ");
                    string surname = Console.ReadLine();
                    Surname = surname;
                    break;
                
                case (int)DoctorData.Schedule:
                    Console.Write("Введіть початок роботи (від 09:00 до 15:30): ");
                    string workStart = Console.ReadLine();
                    Console.Write("Введіть кінець роботи (від 09:30 до 16:00): ");
                    string workEnd = Console.ReadLine();
                    Schedule = new Schedule(workStart, workEnd);
                    break;
                
                case (int)DoctorData.Speciality:
                    Console.Write("Введіть спеціальність: ");
                    string speciality = Console.ReadLine();
                    Speciality = speciality;
                    break;
            }
        }

        public void AddPatient(Patient patient)
        {
            Patients.Add(patient);
        }
        
        public void ChangePatientData()
        {
            Patient patient = PatientSearch();
            bool isHealthy = patient?.MedicalCard.AddRecord() ?? false;
            if (isHealthy)
            {
                Hospital.PatientsList.Remove(patient);
            }
        }

        public Patient PatientSearch()
        {
            Console.Write("Введіть прізвище пацієнта: ");
            string surname = Console.ReadLine();
            foreach (Patient patient in Patients)
            {
                if (patient.Surname == surname)
                {
                    return patient;
                }
            }
            Console.Write("Такого пацієнта нема");
            Thread.Sleep(1000);
            return null;
        }
    }
}