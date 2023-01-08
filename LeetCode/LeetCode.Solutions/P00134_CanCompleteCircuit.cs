namespace LeetCode.Solutions.P00134_CanCompleteCircuit;

public class Solution
{
    //private int[] _gas;
    //private int[] _cost; 

    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        /*
        if (gas == null || cost == null || gas.Length == 0 || gas.Length != cost.Length) return -1;

        //_gas = gas;
        //_cost = cost;
        for (int i = 0; i < gas.Length; i++) 
        {
            if (_cost[i] == 0 && _gas[i] == 0) continue;
            if (CompletesCircuit(i)) return i;
        }

        return -1;
        */

        int totalTank = 0;
        int currentTank = 0;
        int startingStation = 0;
        for (int i = 0; i < gas.Length; i++) 
        {
            totalTank += gas[i] - cost[i];
            currentTank += gas[i] - cost[i];
            
            if (currentTank < 0) 
            {
                startingStation = i + 1;
                currentTank = 0;
            }
            
        }
        return totalTank >= 0 ? startingStation : -1;
    }

    /*
    private bool CompletesCircuit(int i)
    {
        Func<int, int> nextIndex = (int currentIndex) => currentIndex < _gas.Length - 1 ? currentIndex + 1 : 0;
        int energy = 0;
        int index = i;
        do 
        {
            energy += _gas[index];
            energy -= _cost[index];
            if (energy < 0) return false;
            index = nextIndex(index);
        } 
        while (index != i);

        return true;
    }
    */
}