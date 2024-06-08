<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.

}

public IList<int> LongestCommonSubsequence(int[][] arrays)
{
	int[] indeces = new int[arrays.Length]; 
	
	List<int> matches = new List<int>(); 
	bool done = false;
	while (!done)
	{
		// if current array is less than first array, move to the first element that is >= first array 
		for (int i = 1; i < arrays.Length; i++)
		{
			while(arrays[i][indeces[i]] < arrays[0][indeces[0]]) 
			{
				indeces[i]++;
				if (indeces[i] == arrays[i].Length) 
				{
					done = true; 
					break;
				}
			}
			
			// if current array > first array this can't be a common value, go to next value in first array
			if (arrays[i][indeces[i]] > arrays[0][indeces[0]])
			{
				indeces[0]++;
				if (indeces[0] == arrays[0].Length) 
				{
					done = true;
				}
				break;
			}

			if (done) break;
			// if this is the last row in array this value is in all arrays
			// * add to result
			// * iterate all arrays
			if (i == arrays.Length - 1) 
			{
				matches.Add(arrays[0][indeces[0]]);
				for(int j = 0; j < indeces.Length; j++) 
				{
					indeces[j]++;
					if (indeces[j] == arrays[j].Length) 
					{
						done = true; 
						break;
					}
				}
				
			}
		}
	}
	return matches; 
}

/*
Input: arrays = [[1,3,4],
                 [1,4,7,9]]
Output: [1,4]

Input: arrays = [[2,3,6,8],
                 [1,2,3,5,6,7,10],
                 [2,3,4,6,9]]
Output: [2,3,6]

Input: arrays = [[1,2,3,4,5],
                 [6,7,8]]
Output: []
				 
*/

[Theory]
[InlineData(new[] { 1, 4 }, new[] { 1, 3, 4 }, new[] { 1, 4, 7, 9 })]
[InlineData(new[] { 2, 3, 6 }, new[] { 2, 3, 6, 8 }, new[] { 1, 2, 3, 5, 6, 7, 10 }, new[] { 2, 3, 4, 6, 9 })]
[InlineData(new int[0], new[] { 1, 2, 3, 4, 5 }, new[] { 6, 7, 8 })]
void Test(int[] expected, params int[][] input)
{
	int[] result = LongestCommonSubsequence(input).ToArray();

	Array.Sort(expected);
	Array.Sort(result);

	Assert.Equal(expected, result);
}

