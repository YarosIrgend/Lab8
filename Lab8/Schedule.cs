using System.Collections.Generic;

namespace Lab8
{
    public class Schedule
    {
        private readonly List<string> _schedule = new List<string>();
        public readonly List<string> FreeSchedule;

        public string WorkStart => _schedule[0];

        public string WorkEnd { get; }

        public Schedule(string workStart, string workEnd)
        {
            int startHour = int.Parse(workStart.Substring(0, 2));
            int endHour = int.Parse(workEnd.Substring(0, 2));
            bool startWith30Minutes = workStart.EndsWith("30");
            bool endWith30Minutes = workEnd.EndsWith("30");

            for (int hour = startHour; hour < endHour; hour++)
            {
                if (hour == startHour && startWith30Minutes)
                {
                    _schedule.Add($"{hour}:30");
                }
                else
                {
                    _schedule.Add($"{hour}:00");
                    _schedule.Add($"{hour}:30");
                }
            }

            if (endWith30Minutes)
            {
                _schedule.Add($"{endHour}:00");
            }

            WorkEnd = workEnd;
            FreeSchedule = new List<string>(_schedule);
        }
    }
}