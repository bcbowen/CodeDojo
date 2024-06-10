<Query Kind="Program" />

/*
void Main()
{ }
*/

public static class Utility 
{
	public static string GetQueryDirectory()
	{
		FileInfo file = new FileInfo(Util.CurrentQueryPath);
		return file.DirectoryName;
	}

	public static string GetInputDirectory() 
	{
		//  'C:\Users\benja\git\github\bcbowen\CodeDojo\adventOfCode\2015\Day01\input.txt'.
		return GetQueryDirectory().Replace("adventOfCode", "adventOfCodePrivateFiles").Replace(@"CodeDojo\", ""); 
	}
	
}
