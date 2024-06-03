using System;
using System.Threading;

namespace Lab8
{
    public class Patient : Human
    {
        public MedicalCard MedicalCard { get; }
        
        public Doctor Doctor { get; }

        public bool IsExamined = false;

        public bool IsAppointed; 
        
        public Patient(string name, string surname, Doctor doctor)
        {
            Name = name;
            Surname = surname;
            MedicalCard = new MedicalCard();
            Doctor = doctor;
        }

        public void AddAppointment()
        {
            if (IsAppointed)
            {
                Console.WriteLine("Пацієнт вже записаний на прийом");
                Thread.Sleep(1000);
                return;
            }
            Console.Write("Введіть час прийому: ");
            string chosenTime = Console.ReadLine();
            foreach (var time in Doctor.Schedule.FreeSchedule)
            {
                if (time == chosenTime)
                {
                    Doctor.Schedule.FreeSchedule.Remove(time);
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
                    IsAppointed = true;
                    Console.WriteLine("Записано");
                    Thread.Sleep(1000);
                    return;
                }
            }

            Console.WriteLine("Лікар в цей час не приймає або зайнятий");
            Thread.Sleep(1000);
        }
    }
}