<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"

void Main()
{
	RunTests(); 
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	List<string> dimensions = new List<string>();
	using (StreamReader reader = new StreamReader(path)) 
	{
		string line;
		while((line = reader.ReadLine()) != null) {
			dimensions.Add(line); 
		}
		reader.Close(); 
	}
	string input = File.ReadAllText(path);
	Part1(dimensions);
	Part2(dimensions);
}

// You can define other methods, fields, classes and namespaces here
int CalcPaper(int l, int w, int h) 
{
	int[] dimensions = new int[] {l, w, h}; 
	Array.Sort(dimensions); 
	
	int extra = dimensions[0] * dimensions[1]; 
	
	return 2 * l * w + 2 * l * h + 2 * w * h + extra; 
	
}

int CalcRibbon(int l, int w, int h)
{
	/*
	The ribbon required to wrap a present is the shortest distance around its sides, 
	or the smallest perimeter of any one face. 
	
	Each present also requires a bow made out of ribbon as well; 
	the feet of ribbon required for the perfect bow is equal to the cubic feet of volume of the present. 
	*/
	int[] dimensions = new int[] { l, w, h };
	Array.Sort(dimensions);

	int extra = l * w * h;

	return 2 * dimensions[0] + 2 * dimensions[1] + extra;

}

int CalcPaperTotal(List<string> dimensions) 
{
	int total = 0;

	foreach(string dimension in dimensions) 
	{
		string[] parsed = dimension.Split('x');
		Assert.Equal(parsed.Length, 3);
		int l = int.Parse(parsed[0]);
		int w = int.Parse(parsed[1]);
		int h = int.Parse(parsed[2]);
		int result = CalcPaper(l, w, h);
		total += result;
	}

	return total; 
}

int CalcRibbonTotal(List<string> dimensions)
{
	int total = 0;

	foreach (string dimension in dimensions)
	{
		string[] parsed = dimension.Split('x');
		Assert.Equal(parsed.Length, 3);
		int l = int.Parse(parsed[0]);
		int w = int.Parse(parsed[1]);
		int h = int.Parse(parsed[2]);
		int result = CalcRibbon(l, w, h);
		total += result;
	}

	return total;
}

void Part1(List<string> dimensions)
{
	int result = CalcPaperTotal(dimensions);
	Console.WriteLine($"Part1 total: {result}"); 
}

void Part2(List<string> dimensions) 
{
	int result = CalcRibbonTotal(dimensions);
	Console.WriteLine($"Part2 total: {result}"); 
}


/*
A present with dimensions 2x3x4 requires 2*6 + 2*12 + 2*8 = 52 square feet of wrapping paper plus 6 square feet of slack, for a total of 58 square feet.
A present with dimensions 1x1x10 requires 2*1 + 2*10 + 2*10 = 42 square feet of wrapping paper plus 1 square foot of slack, for a total of 43 square feet.
*/

[Theory]
[InlineData("2x3x4", 58)]
[InlineData("1x1x10", 43)]
void Part1Test(string input, int expected) 
{
	int result = CalcPaperTotal(new List<string> {input}); 
	Assert.Equal(expected, result); 
}

/*
A present with dimensions 2x3x4 requires 2+2+3+3 = 10 feet of ribbon to wrap the present plus 2*3*4 = 24 feet of 
ribbon for the bow, for a total of 34 feet.

A present with dimensions 1x1x10 requires 1+1+1+1 = 4 feet of ribbon to wrap the present plus 1*1*10 = 10 feet of
 ribbon for the bow, for a total of 14 feet.
*/

[Theory]
[InlineData("2x3x4", 34)]
[InlineData("1x1x10", 14)]
void Part2Test(string input, int expected)
{
	int result = CalcRibbonTotal(new List<string> { input });
	Assert.Equal(expected, result);
}

