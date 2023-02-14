using LeetCode.Solutions.Medium.P00729_MyCalendar;

namespace LeetCode.Tests.Medium.P00729_MyCalendar;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [Test]
    public void BookFirstAppointmentSucceeds()
    {
        bool expected = true;
        MyCalendar myCalendar = new MyCalendar();
        bool result = myCalendar.Book(10, 20);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void BookConflictingAppointmentFails()
    {
        bool expected = false;
        MyCalendar myCalendar = new MyCalendar();
        myCalendar.Book(10, 20);
        bool result = myCalendar.Book(15, 25);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void BookAppointmentAtEndSucceeds()
    {
        bool expected = true;
        MyCalendar myCalendar = new MyCalendar();
        myCalendar.Book(10, 20);
        bool result = myCalendar.Book(20, 30);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void BookAppointmentAtBeginningSucceeds()
    {
        bool expected = true;
        MyCalendar myCalendar = new MyCalendar();
        myCalendar.Book(10, 20);
        bool result = myCalendar.Book(5, 10);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void BookAppointmentInMiddleSucceeds()
    {
        bool expected = true;
        MyCalendar myCalendar = new MyCalendar();
        myCalendar.Book(10, 20);
        myCalendar.Book(30, 40);
        myCalendar.Book(50, 60);
        bool result = myCalendar.Book(45, 47);
        Assert.That(result, Is.EqualTo(expected));
    }


}