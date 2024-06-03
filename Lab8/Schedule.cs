using System.Collections.Generic;

namespace Lab8
{
    public class Schedule
    {
        private readonly List<string> _schedule = new List<string>();
        public List<string> FreeSchedule = new List<string>();
        private readonly string _workEnd;
        
        public string WorkStart
        {
            get => _schedule[0];
        }

        public string WorkEnd
        {
            get => _workEnd;
        }
        
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

            _workEnd = workEnd;
            FreeSchedule = new List<string>(_schedule);
        }
    }
}