using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab8
{
    public class Patient : Human
    {
        public MedicalCard MedicalCard { get; set; }
        
        public Doctor Doctor { get; set; }
        
        public Patient(string name, string surname, Doctor doctor)
        {
            Name = name;
            Surname = surname;
            MedicalCard = new MedicalCard();
            Doctor = doctor;
        }

        public void AddAppointment(Hospital hospital)
        {
            Console.Clear();
            Console.Write("Введіть час прийому: ");
            string chosenTime = Console.ReadLine();
            foreach (var time in Doctor.Schedule.FreeSchedule)
            {
                if (time == chosenTime)
                {
                    Console.WriteLine("Записано");
                    Doctor.Schedule.FreeSchedule.Remove(time);
                    Thread.Sleep(1000);
                    Appointment appointment = new Appointment
                    {
                        Time = chosenTime,
                        Doctor = Doctor,
                        Patient = this
                    };
                    Appointments.Add(appointment);
                    Doctor.Appointments.Add(appointment);
                    Doctor.AddPatient(this);
                    Doctor.Schedule.FreeSchedule.Remove(chosenTime);
                }
            }
            Console.WriteLine("Лікар в цей час не приймає або зайнятий");
            Thread.Sleep(1000);
        }
    }
}