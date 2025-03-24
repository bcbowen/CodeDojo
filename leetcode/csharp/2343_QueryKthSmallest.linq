<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int[] SmallestTrimmedNumbers(string[] nums, int[][] queries)
{
	Dictionary<int, (int, string)[]> arrayCache = new Dictionary<int, (int, string)[]>();
	(int, string)[] trimmedNums = new (int, string)[nums.Length];
	int[] result = new int[queries.Length];

	for (int i = 0; i < queries.Length; i++)
	{
		int[] query = queries[i];
		if (arrayCache.ContainsKey(query[1]))
		{
			trimmedNums = arrayCache[query[1]];
		}
		else
		{
			trimmedNums = new (int, string)[nums.Length];
			for (int j = 0; j < nums.Length; j++)
			{
				string num = nums[j];
				string value = TrimNumber(num, query[1]);
				trimmedNums[j] = (j, value);
			}
			Array.Sort(trimmedNums, CompareTrimmedValues);
			arrayCache.Add(query[1], trimmedNums);
		}

		result[i] = trimmedNums[query[0] - 1].Item1;
	}

	return result;
}

internal int CompareTrimmedValues((int index, string val) v1, (int index, string val) v2)
{
	if (v1.val != v2.val) return v1.val.CompareTo(v2.val);
	
	return v1.index.CompareTo(v2.index); 
}

internal string TrimNumber(string num, int places)
{
	if (places == num.Length) return num;
	if (places > num.Length) return num.PadLeft(places, '0');

	return num.Substring(num.Length - places);
}

#region Tests

[Theory]
[InlineData("123", 2, "23")]
[InlineData("23", 2, "23")]
[InlineData("3", 2, "03")]
[InlineData("1234", 2, "34")]
[InlineData("1234", 4, "1234")]
[InlineData("1234", 5, "01234")]
[InlineData("1234", 1, "4")]
private void TrimNumberTests(string num, int places, string expected)
{
	string result = TrimNumber(num, places);
	Assert.Equal(expected, result);
}

/*
Example 1:

Input: nums = ["102","473","251","814"], queries = [[1,1],[2,3],[4,2],[1,2]]
Output: [2,2,1,0]
Explanation:
1. After trimming to the last digit, nums = ["2","3","1","4"]. The smallest number is 1 at index 2.
2. Trimmed to the last 3 digits, nums is unchanged. The 2nd smallest number is 251 at index 2.
3. Trimmed to the last 2 digits, nums = ["02","73","51","14"]. The 4th smallest number is 73.
4. Trimmed to the last 2 digits, the smallest number is 2 at index 0.
   Note that the trimmed number "02" is evaluated as 2.
Example 2:

Input: nums = ["24","37","96","04"], queries = [[2,1],[2,2]]
Output: [3,0]
Explanation:
1. Trimmed to the last digit, nums = ["4","7","6","4"]. The 2nd smallest number is 4 at index 3.
   There are two occurrences of 4, but the one at index 0 is considered smaller than the one at index 3.
2. Trimmed to the last 2 digits, nums is unchanged. The 2nd smallest number is 24.
*/

[Fact]
void TroubleshootingTest()
{
	int[][] queries = { new[] { 6, 2 } };
	string[] nums = { "7062852270146477248296527", "8433780701670054260678760", "8699421879227760163019849", "7708276868930722275669591", "5074829025635016047494703", "5896327888048068611168261", "7260190089159791786288449", "5781138574494763732963172", "3205437840168891808107684", "5391561242659929681878939", "9291899334089749518212291", "8708326599236172552237668", "3618812336262173046978703", "4807369922822632937475631", "0316892108136392839378991", "8367705082821693868985331", "2107315678805939657548178", "9907244113601275760502412", "4677127508895251971677534", "1439698519575527518052264", "2511775183710951968637133", "6664307020593448841804234", "3713561166640567497350787", "9222117189171058392839857", "9814178925901695758525967", "1730249210741355068666166", "4032999420142272853817457" };
	int[] expected = { 15 };
	int[] result = SmallestTrimmedNumbers(nums, queries);
	Assert.Equal(expected, result);
}

[Fact]
void BigTest()
{
	string[] nums = { "7062852270146477248296527", "8433780701670054260678760", "8699421879227760163019849", "7708276868930722275669591", "5074829025635016047494703", "5896327888048068611168261", "7260190089159791786288449", "5781138574494763732963172", "3205437840168891808107684", "5391561242659929681878939", "9291899334089749518212291", "8708326599236172552237668", "3618812336262173046978703", "4807369922822632937475631", "0316892108136392839378991", "8367705082821693868985331", "2107315678805939657548178", "9907244113601275760502412", "4677127508895251971677534", "1439698519575527518052264", "2511775183710951968637133", "6664307020593448841804234", "3713561166640567497350787", "9222117189171058392839857", "9814178925901695758525967", "1730249210741355068666166", "4032999420142272853817457" };
	int[][] queries = 
	{ 
		new[] { 5, 21 }, 
		new[] { 23, 7 }, 
		new[] { 6, 2 }, 
		new[] { 27, 8 }, 
		new[] { 14, 21 }, 
		new[] { 25, 21 }, 
		new[] { 26, 23 }, 
		new[] { 12, 19 }, 
		new[] { 7, 8 }, 
		new[] { 25, 9 }, 
		new[] { 11, 8 }, 
		new[] { 17, 17 }, 
		new[] { 21, 8 }, 
		new[] { 1, 18 }, 
		new[] { 16, 18 }, 
		new[] { 13, 1 }, 
		new[] { 27, 7 }, 
		new[] { 11, 1 }, 
		new[] { 4, 7 }, 
		new[] { 24, 14 }, 
		new[] { 9, 1 }, 
		new[] { 14, 25 }, 
		new[] { 2, 13 }, 
		new[] { 7, 21 }, 
		new[] { 15, 1 }, 
		new[] { 9, 6 }, 
		new[] { 7, 2 }, 
		new[] { 23, 20 }, 
		new[] { 15, 20},
		new[] {21,1}
	}; 
	int[] expected = { 6, 24, 15, 22, 2, 14, 5, 16, 14, 13, 0, 3, 15, 21, 18, 8, 14, 12, 18, 10, 17, 7, 22, 25, 19, 22, 20, 6, 0, 24 };
	int[] result = SmallestTrimmedNumbers(nums, queries);
	Assert.Equal(expected, result);

}

[Theory]
[InlineData(new[] { "102", "473", "251", "814" }, new[] { 2, 2, 1, 0 }, new[] { 1, 1 }, new[] { 2, 3 }, new[] { 4, 2 }, new[] { 1, 2 })]
[InlineData(new[] { "24", "37", "96", "04" }, new[] { 3, 0 }, new[] { 2, 1 }, new[] { 2, 2 })]
[InlineData(new[] { "64333639502", "65953866768", "17845691654", "87148775908", "58954177897", "70439926174", "48059986638", "47548857440", "18418180516", "06364956881", "01866627626", "36824890579", "14672385151", "71207752868" },
new[] { 1, 5, 11, 10, 7, 0, 0, 1, 13, 13, 5, 12 },
new[] { 9, 4 },
new[] { 6, 1 },
new[] { 3, 8 },
new[] { 12, 9 },
new[] { 11, 4 },
new[] { 4, 9 },
new[] { 2, 7 },
new[] { 10, 3 },
new[] { 13, 1 },
new[] { 13, 1 },
new[] { 6, 1 },
new[] { 5, 10 })]
void Test(string[] nums, int[] expected, params int[][] queries)
{
	int[] result = SmallestTrimmedNumbers(nums, queries);
	// result.Dump();
	Assert.Equal(expected, result);
}

#endregion