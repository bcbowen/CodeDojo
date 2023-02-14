namespace LeetCode.Solutions.Easy.P01603_DesingParkingSystem;

public class ParkingSystem
{
    private int _big;
    private int _medium;
    private int _small;


    public ParkingSystem(int big, int medium, int small)
    {
        _big = big;
        _medium = medium;
        _small = small;
    }

    public bool AddCar(int carType)
    {
        switch (carType)
        {
            case 1:
                if (_big < 1) return false;
                _big--;
                break;
            case 2:
                if (_medium < 1) return false;
                _medium--;
                break;
            case 3:
                if (_small < 1) return false;
                _small--;
                break;
        }
        return true;
    }
}
