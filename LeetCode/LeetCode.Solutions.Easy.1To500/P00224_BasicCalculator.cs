namespace LeetCode.Solutions.Easy.P00224_BasicCalculator;

public class Solution
{
    // TODO: Finish this
    public int Calculate(string s)
    {
        return Resolve(s);
    }

    internal int Negate(string expr)
    {
        return -Resolve(expr);
    }

    internal int Resolve(string expr)
    {
        int val = 0;
        foreach (char c in expr)
        {
            switch (c)
            {
                case ' ':
                    continue;


            }
        }
        return val;
    }

    /*
	internal (string l, string r, string op) Parse(string expr)
	{
		foreach (char c in expr) 
		{
			
		}
	}
	*/
}