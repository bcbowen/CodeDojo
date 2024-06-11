<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"
void Main()
{
	RunTests();  
	Part1();
	Part2(); 
}

void Part1() 
{
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	string json = File.ReadAllText(path);
	int result = TotalNumbersInJson(json);
	Console.WriteLine($"Part 1 result: {result}"); 
}

int TotalNumbersInJson(string json) 
{
	JToken t = JToken.Parse(json); 
	
	return GetTotals(t);
}

private int GetTotals(JToken token) 
{
	int total = 0;

	if (token.Type == JTokenType.Object)
	{
		foreach (var property in token.Children<JProperty>())
		{
			total += GetTotals(property.Value);
		}
	}
	else if (token.Type == JTokenType.Array)
	{
		foreach (var item in token.Children())
		{
			total += GetTotals(item);
		}
	}
	else if (token.Type == JTokenType.Integer)
	{
		total += (int)token;
	}

	return total;
}

void Part2()
{
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	string json = File.ReadAllText(path);
	int result = TotalNumbersInJson2(json);
	Console.WriteLine($"Part 2 result: {result}");
}

int TotalNumbersInJson2(string json)
{
	JToken t = JToken.Parse(json);

	return GetTotals2(t);
}



private int GetTotals2(JToken token)
{
	int total = 0;

	if (token.Type == JTokenType.Object)
	{
		int objectTotal = 0; 
		foreach (var property in token.Children<JProperty>())
		{
			if (property.Value.ToString() == "red") 
			{
				objectTotal = 0; 
				break;
			}
			objectTotal += GetTotals2(property.Value);
		}
		total += objectTotal; 
	}
	else if (token.Type == JTokenType.Array)
	{
		foreach (var item in token.Children())
		{
			total += GetTotals2(item);
		}
	}
	else if (token.Type == JTokenType.Integer)
	{
		total += (int)token;
	}

	return total;
}


/*
[1,2,3] and {"a":2,"b":4} both have a sum of 6.
[[[3]]] and {"a":{"b":4},"c":-1} both have a sum of 3.
{"a":[-1,1]} and [-1,{"a":1}] both have a sum of 0.
[] and {} both have a sum of 0.
*/
[Theory]
[InlineData("[1,2,3]", 6)]
[InlineData("{\"a\":2,\"b\":4}", 6)]
[InlineData("[[[3]]]", 3)]
[InlineData("{\"a\":{\"b\":4},\"c\":-1}", 3)]
[InlineData("{\"a\":[-1,1]}", 0)]
[InlineData("[-1,{\"a\":1}]", 0)]
[InlineData("[]", 0)]
[InlineData("{}", 0)]
void Part1Test(string json, int expected) 
{
	int result = TotalNumbersInJson(json);
	Assert.Equal(expected, result); 
}

/*
[1,2,3] still has a sum of 6.
[1,{"c":"red","b":2},3] now has a sum of 4, because the middle object is ignored.
{"d":"red","e":[1,2,3,4],"f":5} now has a sum of 0, because the entire structure is ignored.
[1,"red",5] has a sum of 6, because "red" in an array has no effect.
*/
[Theory]
[InlineData("[1,2,3]", 6)]
[InlineData("[1,{\"c\":\"red\",\"b\":2},3]", 4)]
[InlineData("{\"d\":\"red\",\"e\":[1,2,3,4],\"f\":5}", 0)]
[InlineData("[1,\"red\",5]", 6)]
void Part2Test(string json, int expected)
{
	int result = TotalNumbersInJson2(json);
	Assert.Equal(expected, result);
}