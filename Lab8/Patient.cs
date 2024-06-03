using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab8
{
    public class Patient : Human
    {
        public MedicalCard MedicalCard { get; set; }

        public Patient(string name, string surname)
        {
            Name = name;
            Surname = surname;
            MedicalCard = new MedicalCard();
        }

        public void AddAppointment(Hospital hospital)
        {
            Console.Clear();
            Doctor doctor = hospital.DoctorSearch();
            if (doctor == null)
            {
                return;
            }
            Console.Write("Введіть час прийому: ");
            string chosenTime = Console.ReadLine();
            foreach (var time in doctor.Schedule.FreeSchedule)
            {
                if (time == chosenTime)
                {
                    Console.WriteLine("Записано");
                    doctor.Schedule.FreeSchedule.Remove(time);
                    Thread.Sleep(1000);
                    Appointment appointment = new Appointment
                    {
                        Time = chosenTime,
                        Doctor = doctor,
                        Patient = this
                    };
                    Appointments.Add(appointment);
                    doctor.Appointments.Add(appointment);
                    doctor.AddPatient(this);
                    doctor.Schedule.FreeSchedule.Remove(chosenTime);
                }
            }
            Console.WriteLine("Лікар в цей час не приймає або зайнятий");
            Thread.Sleep(1000);
        }
    }
}