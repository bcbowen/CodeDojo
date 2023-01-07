using LeetCode.Solutions.P01603_DesingParkingSystem;

namespace LeetCode.Tests.P01603_DesingParkingSystem;

public class Tests
{
    [Test]
    public void Example1Test()
    {
        ParkingSystem system = new ParkingSystem(1, 1, 0);
        bool result;
        bool expected;
        expected = true;
        result = system.AddCar(1);
        Assert.AreEqual(expected, result);
        result = system.AddCar(2);
        Assert.AreEqual(expected, result);

        expected = false;
        result = system.AddCar(3);
        Assert.AreEqual(expected, result);
        result = system.AddCar(1);
        Assert.AreEqual(expected, result);
    }

}