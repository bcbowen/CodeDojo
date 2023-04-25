<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Solution : Reader4
{
	/**
     * @param buf Destination buffer
     * @param n   Number of characters to read
     * @return    The number of actual characters read
     */
	public int Read(char[] buf, int n)
	{
		int copiedChars = 0;
		int readChars = 4;
		char[] buf4 = new char[4]; 
		
		while (copiedChars < n && readChars == 4)
		{
			readChars = read4(buf4);
			for (int i = 0; i < readChars; i++)
			{
				if (copiedChars == n) return copiedChars;
				buf[copiedChars] = buf4[i];
				copiedChars++;
			}
		}
		return copiedChars;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

#endregion