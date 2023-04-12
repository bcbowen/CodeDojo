<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
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
		if (end<= _appointments[0].Begin)
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

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */


/*
Input
["MyCalendar", "book", "book", "book"]
[[], [10, 20], [15, 25], [20, 30]]
Output
[null, true, false, true]

Explanation
MyCalendar myCalendar = new MyCalendar();
myCalendar.book(10, 20); // return True
myCalendar.book(15, 25); // return False, It can not be booked because time 15 is already booked by another event.
myCalendar.book(20, 30); // return True, The event can be booked, as the first event takes every time less than 20, but not including 20.
*/

[Fact]
void BookFirstAppointmentSucceeds()
{
	bool expected = true;
	MyCalendar myCalendar = new MyCalendar();
	bool result = myCalendar.Book(10, 20);
	Assert.Equal(expected, result);
}

[Fact]
void BookConflictingAppointmentFails()
{
	bool expected = false;
	MyCalendar myCalendar = new MyCalendar();
	myCalendar.Book(10, 20);
	bool result = myCalendar.Book(15, 25);
	Assert.Equal(expected, result);
}

[Fact]
void BookAppointmentAtEndSucceeds()
{
	bool expected = true;
	MyCalendar myCalendar = new MyCalendar();
	myCalendar.Book(10, 20);
	bool result = myCalendar.Book(20, 30);
	Assert.Equal(expected, result);
}

[Fact]
void BookAppointmentAtBeginningSucceeds()
{
	bool expected = true;
	MyCalendar myCalendar = new MyCalendar();
	myCalendar.Book(10, 20);
	bool result = myCalendar.Book(5, 10);
	Assert.Equal(expected, result);
}

[Fact]
void BookAppointmentInMiddleSucceeds()
{
	bool expected = true;
	MyCalendar myCalendar = new MyCalendar();
	myCalendar.Book(10, 20);
	myCalendar.Book(30, 40);
	myCalendar.Book(50, 60);
	bool result = myCalendar.Book(45, 47);
	Assert.Equal(expected, result);
}
