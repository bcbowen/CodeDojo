<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  
	string pwd = "hepxcrrq";
	Part1And2(pwd); 
	
}


const string letters = "abcdefghijklmnopqrstuvwxyz";

void Part1And2(string password) 
{
	string newPassword = FindNextPassword(password);
	Console.WriteLine($"Part 1 nextpwd = {newPassword}"); 
	newPassword = FindNextPassword(newPassword); 
	Console.WriteLine($"Part 2 nextpwd = {newPassword}"); 
}

int GetIndex(char c)
{
	for (int i = 0; i < letters.Length; i++) 
	{
		if (letters[i] == c) return i;
	}
	
	throw new ArgumentException("Invalid character " + c); 
}


string FindNextPassword(string password)
{
	int i = password.Length - 1;
	StringBuilder newPassword = new StringBuilder(password); 
	int charIndex;
	bool found = false;
	// use writer to debug: 
	//string path = Path.Combine(GetQueryDirectory(), $"log{DateTime.Now.ToString("yyyyMMdd_hhmm")}.txt");
	//using (StreamWriter writer = new StreamWriter(path))
	//{
		while (!found)
		{
			charIndex = GetIndex(newPassword[i]) + 1;
			while (charIndex < letters.Length)
			{
				newPassword[i] = letters[charIndex];
				//writer.WriteLine(newPassword.ToString()); 
				if (IsValid(newPassword.ToString()))
				{
					found = true;
					break;
				}
				charIndex++;
			}
			if (!found)
			{
				newPassword[i] = 'a';
				Carry(i - 1, newPassword);
			}

		}
		//writer.Close(); 
	//}

	return newPassword.ToString();
}

private void Carry(int i, StringBuilder password) 
{
	if (i < 0) 
	{
		password.Insert(0, letters[0]); 
		return;
	}
	
	int charIndex = GetIndex(password[i]);
	if (charIndex < letters.Length - 1) 
	{
		password[i] = letters[charIndex + 1];
	}
	else 
	{
		password[i] = letters[0]; 
		Carry(i - 1, password); 
	}
}

bool IsValid(string password) 
{
	if (HasInvalidCharacters(password)) return false; 
	
	return HasRepeats(password) && HasIncrementingLetters(password); 
}

bool HasRepeats(string password)
{
	// redo this: doesn't ensure chars are together!
	//var charCounts = password.GroupBy(c => c).ToDictionary(k => k, c => c.Count()); 
	//return charCounts.Values.Where(v => v > 1).Count() > 1;
	List<char> found = new List<char>(2); 
	for(int i = 1; i < password.Length; i++)
	{
		if (password[i] == password[i - 1])
		{
			if (!found.Contains(password[i]))
			{
				if (found.Count > 0)
				{
					return true;
				}
				else
				{
					found.Add(password[i]);
				}
			}
			else 
			{
				found.Add(password[i]); 
			}
		}
	}
	
	return false; 
}

bool HasInvalidCharacters(string password)
{
	if (password.Contains('i') || password.Contains('l') || password.Contains('o')) return true; 
	
	return false; 
}

bool HasIncrementingLetters(string password) 
{
	for (int i = 2; i < password.Length; i++) 
	{
		int index = GetIndex(password[i]);
		if (index < 2) continue; 
		if (password[i - 1] == letters[index - 1])
		{
			if (password[i - 2] == letters[index - 2]) return true;
		}
	}
	
	return false; 
}

/*
Incrementing is just like counting with numbers: xx, xy, xz, ya, yb, and so on. Increase the rightmost letter one step; if 
it was z, it wraps around to a, and repeat with the next letter to the left until one doesn't wrap around.

Unfortunately for Santa, a new Security-Elf recently started, and he has imposed some additional password requirements:

Passwords must include one increasing straight of at least three letters, like abc, bcd, cde, and so on, up to xyz. They 
cannot skip letters; abd doesn't count.
Passwords may not contain the letters i, o, or l, as these letters can be mistaken for other characters and are therefore 
confusing.
Passwords must contain at least two different, non-overlapping pairs of letters, like aa, bb, or zz.
*/


/*
The next password after abcdefgh is abcdffaa.
The next password after ghijklmn is ghjaabcc,
*/

[Theory]
[InlineData("abcdefgh", "abcdffaa")]
[InlineData("ghijklmn", "ghjaabcc")]
void TestFindPassword(string password, string expected)
{
	string result = FindNextPassword(password); 
	Assert.Equal(expected, result); 
	
}

[Theory]
[InlineData("aaaaaaa", false)]
[InlineData("abcddee", true)]
[InlineData("ddabcee", true)]
[InlineData("ddabcdd", false)]
[InlineData("dfdaabbcd", true)]
[InlineData("ghkaabcb", false)]
void IsValidTest(string password, bool expected)
{
	bool result = HasRepeats(password);
	Assert.Equal(expected, result);

}


[Theory]
[InlineData("aaaaaaa", false)]
[InlineData("abcddee", true)]
[InlineData("ddabcee", true)]
[InlineData("ddabcdd", false)]
[InlineData("dfdaabbcd", true)]
[InlineData("ghkaabcb", false)]
void RepeatsTest(string password, bool expected)
{
	bool result = HasRepeats(password);
	Assert.Equal(expected, result);

}


[Theory]
[InlineData("aaaaaaa", false)]
[InlineData("abcdddd", true)]
[InlineData("ddddabc", true)]
[InlineData("dddabcd", true)]
void IncrementingLettersTest(string password, bool expected)
{
	bool result = HasIncrementingLetters(password); 
	Assert.Equal(expected, result); 

}
