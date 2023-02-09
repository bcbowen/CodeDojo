namespace LeetCode.Solutions.Medium.P00134_CanCompleteCircuit;

public class Solution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
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
}