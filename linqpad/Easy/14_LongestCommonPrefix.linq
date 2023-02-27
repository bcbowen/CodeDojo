<Query Kind="Program" />

void Main()
{
	Test(new string[] { "flower", "flow", "flight"}, "fl");
}

private void Test(string[] values, string expected) 
{
	Solution solution = new Solution();
	string prefix = solution.LongestCommonPrefix(values); 
	
	if (expected == prefix)
	{
		Console.WriteLine("PASS");
	}
	else
	{
		Console.WriteLine($"FAIL; Expected {expected} Got {prefix}");
	}
	
}

public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        StringBuilder prefix = new StringBuilder(); 
        int i = 0; 
        bool done = false;
        
        while (!done)
        {
            if (i >= strs[0].Length)
            {
                done = true; 
                continue;
            }
            char current = strs[0][i]; 
            for(int j = 1; j < strs.Length; j++)
            {
                if (i >= strs[j].Length)
                {
                    done = true;
                    break;
                }
                if (strs[j][i] != current)
                {
                    done = true;
                    break;
                }
                
            }
            if (!done)
            {
                prefix.Append(current);
            }
            i++;
        }
        return prefix.ToString();
	}
}