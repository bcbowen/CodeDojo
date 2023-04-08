<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Solution
{
	public IList<string> FindItinerary(IList<IList<string>> tickets)
	{
		Dictionary<string, List<string>> trips = new Dictionary<string, List<string>>();
		List<string> result = new List<string>();

		foreach (IList<string> ticket in tickets)
		{
			if (!trips.ContainsKey(ticket[0]))
			{
				trips.Add(ticket[0], new List<string>());
			}
			trips[ticket[0]].Add(ticket[1]);
		}

		Stack<string> departureStack = new Stack<string>();
		departureStack.Push("JFK");
		while (departureStack.Count > 0)
		{
			string origin = departureStack.Pop();
			result.Add(origin);
			string destination;
			if (trips.ContainsKey(origin) && trips[origin].Count > 0)
			{
				destination = trips[origin].OrderBy(s => s).First();
				departureStack.Push(destination);
			}
			else
			{
				departureStack.Push(origin);
			}
		}

		return result;
	}
}

[Theory]
[InlineData(new[] { "JFK", "MUC", "LHR", "SFO", "SJC" }, new[] { "MUC", "LHR" }, new[] { "JFK", "MUC" }, new[] { "SFO", "SJC" }, new[] { "LHR", "SFO" })]
[InlineData(new[] { "JFK", "ATL", "JFK", "SFO", "ATL", "SFO" }, new[] { "JFK", "SFO" }, new[] { "JFK", "ATL" }, new[] { "SFO", "ATL" }, new[] { "ATL", "JFK" }, new[] { "ATL", "SFO" })]
public void Test(string[] expected, params string[][] tickets)
{
	IList<string> result = new Solution().FindItinerary(tickets);
	Assert.Equal(expected, result);
}