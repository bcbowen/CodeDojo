<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

/// <summary>
/// ex: 
///     stock price  7 1 5 3 6 4
///                  5 5 3 3 0 0  <- right profits
/// -> left profits  0 0 4 4 5 5 
/// max left + right = 4 + 3 = 7
/// </summary>

public int MaxProfit(int[] prices) 
{
	int length = prices.Length; 
	if (length <= 1) return 0; 
	
	int leftMin = prices[0]; 
	int rightMax = prices[length - 1]; 
	
	int[] leftProfits = new int[length]; 
	int[] rightProfits = new int[length + 1];

	// bidirectional dp array
	for (int l = 1; l < length; l++)
	{
		leftProfits[l] = Math.Max(leftProfits[l - 1], prices[l] - leftMin); 
		leftMin = Math.Min(leftMin, prices[l]); 
		
		int r = length - l - 1;
		rightProfits[r] = Math.Max(rightProfits[r + 1], rightMax - prices[r]); 
		rightMax = Math.Max(rightMax, prices[r]);
	}
	
	int maxProfit = 0;

	for (int i = 0; i < length; i++) 
	{
		maxProfit = Math.Max(maxProfit, leftProfits[i] + rightProfits[i + 1]); 
	}
	return maxProfit; 
}

public int MaxProfit_First(int[] prices)
{
	if (prices.Length < 2) return 0;

	int[][] profits = new int[2][]; 
	profits[0] = new int[prices.Length]; 
	profits[1] = new int[prices.Length];

	int i; 
	int maxProfit = 0; 
	for (i = prices.Length - 1; i >= 0; i--)
	{
		profits[0][i] = MaxProfitInRange(i, prices.Length - 1, prices); 
	}

	for (i = 0; i < prices.Length; i++)
	{
		profits[1][i] = MaxProfitInRange(0, i, prices);
		if (i < prices.Length - 1) 
		{
			maxProfit = Math.Max(maxProfit, profits[1][i] + profits[0][i + 1]); 
		}
	}
	maxProfit = Math.Max(maxProfit, profits[1][--i]);

	return maxProfit; 

}

internal int MaxProfitInRange(int start, int end, int[] prices)
{
	if (end - start < 1) return 0;
	int buyPrice = prices[start];
	int profit = 0;
	for (int i = start + 1; i <= end; i++)
	{
		if (prices[i] < buyPrice)
		{
			buyPrice = prices[i];
		}
		else if (prices[i] > buyPrice)
		{
			profit = Math.Max(profit, prices[i] - buyPrice);
		}
	}

	return profit;
}

#region Tests


/*
Example 1:

Input: prices = [3,3,5,0,0,3,1,4]
Output: 6
Explanation: Buy on day 4 (price = 0) and sell on day 6 (price = 3), profit = 3-0 = 3.
Then buy on day 7 (price = 1) and sell on day 8 (price = 4), profit = 4-1 = 3.
Example 2:

Input: prices = [1,2,3,4,5]
Output: 4
Explanation: Buy on day 1 (price = 1) and sell on day 5 (price = 5), profit = 5-1 = 4.
Note that you cannot buy on day 1, buy on day 2 and sell them later, as you are engaging multiple transactions at the same time. You must sell before buying again.
Example 3:

Input: prices = [7,6,4,3,1]
Output: 0
Explanation: In this case, no transaction is done, i.e. max profit = 0.
*/

[Theory]
[InlineData(new[] { 3, 3, 5, 0, 0, 3, 1, 4 }, 6)]
[InlineData(new[] { 1, 2, 3, 4, 5 }, 4)]
[InlineData(new[] { 7, 6, 4, 3, 1 }, 0)]
[InlineData(new[] { 2, 4, 1 }, 2)]
[InlineData(new[] { 1, 2, 4, 2, 5, 7, 2, 4, 9, 0 }, 13)]
void Test(int[] prices, int expected)
{
	int result = MaxProfit(prices);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData(new[] { 3, 3, 5, 0, 0, 3, 1, 4 }, 0, 0, 0)]
[InlineData(new[] { 3, 3, 5, 0, 0, 3, 1, 4 }, 0, 1, 0)]
[InlineData(new[] { 3, 3, 5, 0, 0, 3, 1, 4 }, 0, 2, 2)]
[InlineData(new[] { 3, 3, 5, 0, 0, 3, 1, 4 }, 7, 7, 0)]
[InlineData(new[] { 3, 3, 5, 0, 0, 3, 1, 4 }, 6, 7, 3)]
[InlineData(new[] { 3, 3, 5, 0, 0, 3, 1, 4 }, 5, 7, 3)]
[InlineData(new[] { 3, 3, 5, 0, 0, 3, 1, 4 }, 4, 7, 4)]

[InlineData(new[] { 1, 2, 4, 2, 5, 7, 2, 4, 9, 0 }, 0, 5, 6)]
[InlineData(new[] { 1, 2, 4, 2, 5, 7, 2, 4, 9, 0 }, 0, 8, 8)]
[InlineData(new[] { 1, 2, 4, 2, 5, 7, 2, 4, 9, 0 }, 7, 9, 5)]
void TestMaxProfitInRange(int[] prices, int start, int end, int expected)
{
	int result = MaxProfitInRange(start, end, prices);
	Assert.Equal(expected, result);
}

[Fact]
void BigTestCase() 
{
	string path = Path.Combine(GetDataDirectoryPath(), "123_Prices.txt");
	Assert.True(File.Exists(path));
	int[] prices = JsonConvert.DeserializeObject<int[]>(File.ReadAllText(path));
	
	int maxProfit = MaxProfit(prices);
	int expected = 99995; 
	Assert.Equal(expected, maxProfit); 
}

private static string GetDataDirectoryPath()
{
	DirectoryInfo queryPath = new FileInfo(Util.CurrentQueryPath).Directory;
	DirectoryInfo dataDirectory = queryPath.Parent.GetDirectories().First(d => d.Name == "Data");
	return dataDirectory.FullName;
}

#endregion