<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities"

void Main()
{
	RunTests(); 
}

/*
cpy x y copies x (either an integer or the value of a register) into register y.
inc x increases the value of register x by one.
dec x decreases the value of register x by one.
jnz x y jumps to an instruction y away (positive means forward; negative means backward), 
but only if x is not zero.
The jnz instruction moves relative to itself: an offset of -1 would continue at the previous 
instruction, while an offset of 2 would skip over the next instruction.
*/

class Computer 
{
	public int A { get; private set; }
	public int B { get; private set; }
	public int C { get; private set; }
	public int D { get; private set; }


	public void Increment(char register)
	{
		switch(register) 
		{
			case 'a': 
				A++;
				break;
			case 'b':
				B++;
				break;
			case 'c':
				C++;
				break;
			case 'd':
				D++;
				break;
			default:
				throw new ArgumentException($"Invalid register: {register}", "register"); 
		}
	}
	public void Decrement(char register)
	{
		switch (register)
		{
			case 'a':
				A--;
				break;
			case 'b':
				B--;
				break;
			case 'c':
				C--;
				break;
			case 'd':
				D--;
				break;
			default:
				throw new ArgumentException($"Invalid register: {register}", "register");
		}
	}

	public void Run(string fileName) 
	{
		string path = Path.Combine(Utility.GetInputDirectory(), fileName); 
		string[] commands = File.ReadAllLines(path); 
		int i = 0; 
		
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

#endregion