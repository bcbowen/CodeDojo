<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

/*

The canonical path should have the following format:

* The path starts with a single slash '/'.
* Any two directories are separated by a single slash '/'.
* The path does not end with a trailing '/'.
* The path only contains the directories on the path from the root directory to the target file or directory (i.e., no period '.' or double period '..')

Return the simplified canonical path.
*/

public class Solution
{
	public string SimplifyPath(string path)
	{
		Stack<string> directories = new Stack<string>();
		string[] fields = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
		
		foreach (string field in fields)
		{
			switch (field) 
			{
				case ".": // noop
					break;
				case "..":
					if (directories.Count > 0)
					{
						directories.Pop(); 
					}
					break;
				default: 
					directories.Push(field);
					break;
				
			}
		}

		StringBuilder result = new StringBuilder();
		while(directories.Count > 0)
		{
			result.Insert(0, $"/{directories.Pop()}");
		}
		if (result.Length == 0) result.Append('/');
		return result.ToString(); 
	}
}

/*
Example 1:
Input: path = "/home/"
Output: "/home"
Explanation: Note that there is no trailing slash after the last directory name.

Example 2:
Input: path = "/../"
Output: "/"
Explanation: Going one level up from the root directory is a no-op, as the root level is the highest level you can go.

Example 3:
Input: path = "/home//foo/"
Output: "/home/foo"
Explanation: In the canonical path, multiple consecutive slashes are replaced by a single one.
 
*/

[Theory]
[InlineData("/a/../../b/../c//.//", "/c")]
[InlineData("/a/./b/../../c/", "/c")]
[InlineData("/home/", "/home")]
[InlineData("/../", "/")]
[InlineData("/home//foo/", "/home/foo")]
void Test(string path, string expected) 
{
	string result = new Solution().SimplifyPath(path); 
	Assert.Equal(expected, result);
}

