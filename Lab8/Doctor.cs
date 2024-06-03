using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab8
{
    public enum DoctorData
    {
        Name=1,
        Surname,
        Schedule,
        Speciality
    }
    
    public class Doctor : Human
    {
        private Hospital Hospital { get; }
        public Schedule Schedule { get; private set; }
        public string Speciality { get; private set; }
        
        public readonly List<Patient> PatientsList = new List<Patient>();
        
        public Doctor(string name, string surname, Schedule schedule, string speciality, Hospital hospital)
        {
            Name = name;
            Surname = surname;
            Schedule = schedule;
            Speciality = speciality;
            Hospital = hospital;
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
                    Appointments.Clear();
                    foreach (Patient patient in PatientsList)
                    {
                        patient.Appointments.Clear();
                        patient.IsExamined = false;
                        patient.IsAppointed = true;
                    }
                    break;
                
                case (int)DoctorData.Speciality:
                    Console.Write("Введіть спеціальність: ");
                    string speciality = Console.ReadLine();
                    Speciality = speciality;
                    break;
            }
            Console.WriteLine("Змінено");
            Thread.Sleep(1000);
        }

        public void AddPatient(Patient patient)
        {
            PatientsList.Add(patient);
        }
        
        public void ChangePatientData()
        {
            Patient patient = PatientSearch();
            if (!patient.IsExamined)
            {
                Console.WriteLine("Спочатку треба пацієнта обстежити. Запишіть на прийом та пройдіть його");
                Thread.Sleep(2000);
                return;
            }
            bool isHealthy = patient.MedicalCard.AddRecord();
            if (isHealthy)
            {
                Hospital.PatientsList.Remove(patient);
                PatientsList.Remove(patient);
            }
            Console.WriteLine("Записано");
            Thread.Sleep(1000);
        }

        private Patient PatientSearch()
        {
            Console.Write("Введіть прізвище пацієнта: ");
            string surname = Console.ReadLine();
            foreach (Patient patient in PatientsList)
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

        public void PassAppointment()
        {
            Patient patient = PatientSearch();
            if (patient == null)
            {
                return;
            }

            bool appointmentExists = false;
            Appointment appointment = new Appointment();
            foreach (Appointment appointmentToCheck in patient.Appointments)
            {
                if (appointmentToCheck.Doctor == this && appointmentToCheck.Patient == patient)
                {
                    appointment = appointmentToCheck;
                    appointmentExists = true;
                    break;
                }
            }

            if (appointmentExists)
            {
                string time = appointment.Time;
                Appointments.Remove(appointment);
                patient.Appointments.Remove(appointment);
                patient.IsExamined = true;
                patient.IsAppointed = false;
                Schedule.FreeSchedule.Add(time);
                Schedule.FreeSchedule.Sort();
                Console.WriteLine("Обстеження проведено. Можна додавати записи пацієнту");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("Нема запису");
                Thread.Sleep(1000);
            }
        }
    }
}