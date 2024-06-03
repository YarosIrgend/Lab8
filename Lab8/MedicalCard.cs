using System;
using System.Collections.Generic;

namespace Lab8
{
    public class MedicalCard
    {
        public List<MedicalCardRecord> medicalCard = new List<MedicalCardRecord>();

        public bool AddRecord()
        {
            MedicalCardRecord record = new MedicalCardRecord();
            Console.Write("Введіть день: ");
            record.Day = int.Parse(Console.ReadLine());
            Console.Write("Введіть діагноз (Щоб виписати, напишіть \"Здоровий\"): ");
            record.Diagnosis = Console.ReadLine();
            Console.Write("Напишіть коментар: ");
            record.Comment = Console.ReadLine();
            if (record.Diagnosis == "Здоровий")
            {
                return true;
            }
            medicalCard.Add(record);
            return false;
        }

        public void Read()
        {
            foreach (MedicalCardRecord record in medicalCard)
            {
                Console.WriteLine($"День - {record.Day}");
                Console.WriteLine($"Діагноз - {record.Diagnosis}");
                Console.WriteLine($"Коментар - {record.Comment}\n");
            }

            Console.WriteLine("\nНатисніть Enter, щоб закрити");
            Console.Read();
        }
    }
}