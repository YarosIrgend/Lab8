using System.Collections.Generic;

namespace Lab8
{
    public class Human
    {
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public List<Appointment> Appointments { get; } = new List<Appointment>();
    }
}