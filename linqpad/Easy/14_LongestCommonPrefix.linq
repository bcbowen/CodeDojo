<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
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

#region private::Tests

[Theory]
[InlineData(new string[] { "flower", "flow", "flight" }, "fl")]
[InlineData(new string[] { "dog", "racecar", "car" }, "")]
[InlineData(new string[] { "dog", "", "dork" }, "")]
[InlineData(new string[] { "", "racecar", "rat" }, "")]
[InlineData(new string[] { "", "" }, "")]
public void Test(string[] input, string expected)
{
	string result = new Solution().LongestCommonPrefix(input);
	Assert.Equal(expected, result);
}

#endregion