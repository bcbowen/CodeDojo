namespace LeetCode.Solutions.P00729_MyCalendar;

internal class Appointment
{
    public Appointment(int begin, int end)
    {
        Begin = begin;
        End = end;
    }

    public int Begin { get; set; }
    public int End { get; set; }
}

public class MyCalendar
{
    private List<Appointment> _appointments;

    public MyCalendar()
    {
        _appointments = new List<Appointment>();
    }

    public bool Book(int start, int end)
    {
        Appointment appointment = new Appointment(start, end);

        // if appts are empty, or this ends after all existing appointments add to the list at the end
        if (_appointments.Count == 0 || _appointments[_appointments.Count - 1].End <= appointment.Begin)
        {
            _appointments.Add(appointment);
            return true;
        }

        // this ends before all existing appointments, insert at front
        if (end <= _appointments[0].Begin)
        {
            _appointments.Insert(0, appointment);
            return true;

        }

        // find existing appt that this one should go before
        for (int i = 1; i < _appointments.Count; i++)
        {
            if (_appointments[i].Begin >= appointment.End)
            {
                if (_appointments[i - 1].End <= appointment.Begin)
                {
                    // previous appointment doesn't overlap
                    _appointments.Insert(i, appointment);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        return false;
    }
}
