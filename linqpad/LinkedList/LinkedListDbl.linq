<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


private void ShowList(MyLinkedList list) 
{
	MyLinkedList current = list;
	while (current != null) 
	{
		Console.Write(current.Value + " ");
		current = current.Next;
	}
	Console.Write(Environment.NewLine);
}

public class MyLinkedList
{
	public MyLinkedList Head {get; set;}
	public MyLinkedList Next { get; set; }
	public MyLinkedList Previous { get; set; }
	public int Value { get; set; }

	public MyLinkedList()
	{

	}

	public int Get(int index)
	{
		int val = -1;
		int i = 0; 
		MyLinkedList list = Head;

		while(i < index && list?.Next != null) 
		{
			list = list.Next;
			i++; 
		}
		
		if (i == index && list != null) val = list.Value;
		return val;
	}

	public void AddAtHead(int val)
	{
		if (Head == null)
		{
			Head = new MyLinkedList{Value = val};
		}
		else 
		{
			MyLinkedList node = Head;
			Head = new MyLinkedList {Next = node, Value = val};
			node.Previous = Head;
		}
		
	}

	public void AddAtTail(int val)
	{
		if (Head == null) 
		{
			AddAtHead(val);
			return;
		}
		
		MyLinkedList list = Head;
		while(list.Next != null) 
		{
			list = list.Next;
		}

		list.Next = new MyLinkedList {Value = val};
		list.Next.Previous = list;
	}

	public void AddAtIndex(int index, int val)
	{
		if (index == 0) 
		{
			AddAtHead(val);
			return;
		}
		else if (Head == null) 
		{
			return;
		}
		
		int i = 0;
		MyLinkedList current = Head;
		while(i < index && current.Next != null) 
		{
			current = current.Next;
			i++;
		}
		
		if (i == index)
		{
			MyLinkedList node = new MyLinkedList { Value = val };
			current.Previous.Next = node; 
			node.Next = current; 
			node.Previous = current.Previous;
			current.Previous = node;
		}
		else if (i == index - 1)
		{
			MyLinkedList node = new MyLinkedList { Value = val };
			current.Next = node;
			node.Previous = current;
		}
	}

	public void DeleteAtIndex(int index)
	{
		if (Head == null) return;
		
		if (index == 0)
		{
			Head = Head.Next;
			if (Head != null) Head.Previous = null;
			return;
		}
		
		int i = 0;
		MyLinkedList current = Head;
		while (i < index && current.Next != null)
		{
			current = current.Next;
			i++;
		}
		
		if (i == index) 
		{
			MyLinkedList next = current.Next;
			if (next != null)
			{ 
				current.Previous.Next = next;
				next.Previous = current.Previous;
			}
			else 
			{
				current.Previous.Next = null;
				
			}
			//previous.Next = current.Next;	
			current.Previous = null;
			current.Next = null;
		}
	}
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */

// You can define other methods, fields, classes and namespaces here

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

[Fact]
void LinkedListTest1()
{
	Console.WriteLine("*** 1 ***");
	MyLinkedList myLinkedList = new MyLinkedList();
	myLinkedList.AddAtHead(1);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(3);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtIndex(1, 2);    // linked list becomes 1->2->3
	ShowList(myLinkedList.Head);
	int val = myLinkedList.Get(1);              // return 2
	Assert.Equal(2, val);
	ShowList(myLinkedList.Head);
	myLinkedList.DeleteAtIndex(1);    // now the linked list is 1->3
	ShowList(myLinkedList.Head);
	val = myLinkedList.Get(1);              // return 3
	Assert.Equal(3, val);
	ShowList(myLinkedList.Head);
	Console.WriteLine("*** 1 ***");
	Console.WriteLine();
}

[Fact]
void LinkedListTest2()
{
	Console.WriteLine("*** 2 ***");
	MyLinkedList myLinkedList = new MyLinkedList();
	myLinkedList.AddAtHead(7);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtHead(2);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtHead(1);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtIndex(3, 0);
	ShowList(myLinkedList.Head);
	myLinkedList.DeleteAtIndex(2);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtHead(6);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(4);
	ShowList(myLinkedList.Head);
	int val = myLinkedList.Get(4);
	Assert.Equal(4, val);
	myLinkedList.AddAtHead(4);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtIndex(5, 0);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtHead(6);
	ShowList(myLinkedList.Head);
	Console.WriteLine("*** 2 ***");
	Console.WriteLine();
}

[Fact]
void LinkedListTest3()
{
	/*
	Input:
	["MyLinkedList","addAtHead","addAtTail","addAtIndex","get","deleteAtIndex","get"]
	[[],[1],[3],[1,2],[1],[0],[0]]
	Output:
	[null,null,null,null,2,null,1]
	Expected:
	[null,null,null,null,2,null,2]
	*/

	Console.WriteLine("*** 3 ***");
	MyLinkedList myLinkedList = new MyLinkedList();
	myLinkedList.AddAtHead(1);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(3);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtIndex(1, 2);
	ShowList(myLinkedList.Head);
	int val = myLinkedList.Get(1);
	Assert.Equal(2, val);
	ShowList(myLinkedList.Head);
	myLinkedList.DeleteAtIndex(0);
	ShowList(myLinkedList.Head);
	val = myLinkedList.Get(0);
	Assert.Equal(2, val);
	ShowList(myLinkedList.Head);

	Console.WriteLine("*** 3 ***");
	Console.WriteLine();

}

[Fact]
void LinkedListTest4()
{
	Console.WriteLine("*** 4 ***");
	MyLinkedList myLinkedList = new MyLinkedList();
	myLinkedList.AddAtIndex(0, 10);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtIndex(0, 20);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtIndex(1, 30);
	ShowList(myLinkedList.Head);
	int val = myLinkedList.Get(0);
	Assert.Equal(20, val);
	ShowList(myLinkedList.Head);

	Console.WriteLine("*** 4 ***");
	Console.WriteLine();
	/*
	["MyLinkedList","addAtIndex","addAtIndex","addAtIndex","get"]
[[],[0,10],[0,20],[1,30],[0]]
	*/
}

[Fact]
void LinkedListTest5()
{
	/*
	["MyLinkedList","addAtTail","get"]
[[],[1],[0]]
	*/
	Console.WriteLine("*** 5 ***");
	MyLinkedList myLinkedList = new MyLinkedList();
	myLinkedList.AddAtTail(1);
	ShowList(myLinkedList.Head);
	int val = myLinkedList.Get(0);
	Assert.Equal(1, val);
	Console.WriteLine("*** 5 ***");
	Console.WriteLine();
}

[Fact]
void LinkedListTest6()
{
	Console.WriteLine("*** 6 ***");
	MyLinkedList myLinkedList = new MyLinkedList();
	myLinkedList.AddAtHead(38);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(66);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(61);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(76);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(26);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(37);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(8);
	ShowList(myLinkedList.Head);
	myLinkedList.DeleteAtIndex(5);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtHead(4);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtHead(45);
	ShowList(myLinkedList.Head);
	int val = myLinkedList.Get(4);
	Assert.Equal(61, val);
	myLinkedList.AddAtTail(85);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtHead(37);
	ShowList(myLinkedList.Head);
	val = myLinkedList.Get(5);
	Assert.Equal(61, val);
	myLinkedList.AddAtTail(93);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtIndex(10, 23);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(21);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtHead(52);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtHead(15);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtHead(47);
	ShowList(myLinkedList.Head);
	val = myLinkedList.Get(12);
	Assert.Equal(85, val);
	Console.WriteLine("*****");
	myLinkedList.AddAtIndex(6, 24);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtHead(64);
	ShowList(myLinkedList.Head);
	val = myLinkedList.Get(4);
	Assert.Equal(37, val);
	myLinkedList.AddAtHead(31);
	ShowList(myLinkedList.Head);
	myLinkedList.DeleteAtIndex(6);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtHead(40);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(17);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(15);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtIndex(19, 2);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(11);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtHead(86);
	ShowList(myLinkedList.Head);
	val = myLinkedList.Get(17);
	Assert.Equal(23, val);
	myLinkedList.AddAtTail(55);
	ShowList(myLinkedList.Head);
	myLinkedList.DeleteAtIndex(15);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtIndex(14, 95);
	ShowList(myLinkedList.Head);
	myLinkedList.DeleteAtIndex(22);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtHead(66);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(95);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtHead(8);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtHead(47);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(23);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(39);
	ShowList(myLinkedList.Head);
	val = myLinkedList.Get(30);
	Assert.Equal(-1, val);
	val = myLinkedList.Get(27);
	Assert.Equal(95, val);

	/*

	"addAtHead[0]",
	"addAtTail[99]",
	"addAtTail[45]",
	"addAtTail[4]",
	"addAtIndex[9,11]",
	"get[6]"31,
	"addAtHead[81]",
	"addAtIndex[18,32]",
	"addAtHead[20]",
	"addAtTail[13]",
	"addAtTail[42]",
	"addAtIndex[37,91]",
	"deleteAtIndex[36]",
	"addAtIndex[10,37]",
	"addAtHead[96]",
	"addAtHead[57]",
	"deleteAtIndex[20]",
	"addAtTail[89]",
	"deleteAtIndex[18]",
	"addAtIndex[41,5]",
	"addAtTail[23]",
	"addAtHead[75]",
	"get[7]"8,
	"addAtIndex[25,51]",
	"addAtTail[48]",
	"addAtHead[46]",
	"addAtHead[29]",
	"addAtHead[85]",
	"addAtHead[82]",
	"addAtHead[6]",
	"addAtHead[38]",
	"deleteAtIndex[14]",
	"get[1]"6,
	"get[12]"47,
	"addAtHead[42]",
	"get[42]"23,
	"addAtTail[83]",
	"addAtTail[13]",
	"addAtIndex[14,20]",
	"addAtIndex[17,34]",
	"addAtHead"[36],"addAtTail","addAtTail","get","addAtIndex","addAtHead","deleteAtIndex","addAtTail","get","addAtHead","get","addAtHead","deleteAtIndex","get","addAtTail","addAtTail"]
[[],,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,[58],[2],[38],[33,59],[37],[15],[64],[56],[0],[40],[92],[63],[35],[62],[32]]


[null,null,null,null,null,null,null,null,null,null,null,61,null,null,61,null,null,null,null,null,
null,85,null,null,37,null,null,null,null,null,null,null,null,23,
null,null,null,null,null,null,null,null,null,
null,-1,95,
null,null,null,null,null,31,
null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,8,
null,null,null,null,null,null,null,null,
null,6,47,null,23,null,null,null,null,null,null,null,93,null,null,null,null,48,null,93,null,null,59,null,null]
	*/
	Console.WriteLine("*** 6 ***");
	Console.WriteLine();
}

[Fact]
void TestLinkedList7()
{
	Console.WriteLine("*** 7 ***");
	MyLinkedList myLinkedList = new MyLinkedList();
	myLinkedList.AddAtHead(1);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(3);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtIndex(1, 2);
	ShowList(myLinkedList.Head);
	var value = myLinkedList.Get(1);
	Assert.Equal(2, value);
	myLinkedList.DeleteAtIndex(1);
	ShowList(myLinkedList.Head);

	value = myLinkedList.Get(1);
	Assert.Equal(3, value);
	value = myLinkedList.Get(3);
	Assert.Equal(-1, value);

	myLinkedList.DeleteAtIndex(3);
	ShowList(myLinkedList.Head);

	myLinkedList.DeleteAtIndex(0);
	ShowList(myLinkedList.Head);
	value = myLinkedList.Get(0);
	Assert.Equal(3, value);
	myLinkedList.DeleteAtIndex(0);
	ShowList(myLinkedList.Head);

	value = myLinkedList.Get(0);
	Assert.Equal(-1, value);
	/*
	["MyLinkedList","addAtHead","addAtTail","addAtIndex","get",
	"deleteAtIndex","get","get","deleteAtIndex","deleteAtIndex","get","deleteAtIndex","get"]
[[],[1],[3],[1,2],[1]

,[1],[1],[3],[3],[0],[0],[0],[0]]
	*/
	Console.WriteLine("*** 7 ***");
	Console.WriteLine();
}

[Fact]
void LinkedListTest8()
{
	Console.WriteLine("*** 8 ***");
	MyLinkedList myLinkedList = new MyLinkedList();
	myLinkedList.AddAtTail(1);
	ShowList(myLinkedList.Head);
	myLinkedList.AddAtTail(3);
	ShowList(myLinkedList.Head);

	int value = myLinkedList.Get(1);
	Assert.Equal(3, value);
	/*
	["MyLinkedList","addAtTail","addAtTail","get"]
[[],[1],[3],[1]]
Output:
[null,null,null,1]
Expected:
[null,null,null,3]
	*/

	Console.WriteLine("*** 8 ***");
	Console.WriteLine();
}

[Fact]
void LinkedListTest9()
{
	Console.WriteLine("*** 9 ***");
	MyLinkedList myLinkedList = new MyLinkedList();
	myLinkedList.AddAtIndex(1, 0);
	ShowList(myLinkedList.Head);

	int value = myLinkedList.Get(0);
	Assert.Equal(-1, value);
	/*
	["MyLinkedList","addAtIndex","get"]
[[],[1,0],[0]]
	*/
	Console.WriteLine("*** 9 ***");
	Console.WriteLine();
}

#endregion