import pytest

class StringIterator:

    def __init__(self, compressedString: str):
        self.compressedString = compressedString
        self.currentPosition = 0
        self.iterationsLeft = 0
        self.currentChar = ' '
        self.__setNext__()

    def next(self) -> str:
        if self.iterationsLeft > 0: 
            self.iterationsLeft -= 1
            return self.currentChar
        self.__setNext__()
        self.iterationsLeft -= 1
        return self.currentChar


    def hasNext(self) -> bool:
        return self.iterationsLeft > 0 or self.currentPosition < len(self.compressedString)
    
    def __setNext__(self):
        if self.currentPosition < len(self.compressedString): 

            self.currentChar = self.compressedString[self.currentPosition]
            pos = self.currentPosition + 1
            iterVal = ''
            while pos < len(self.compressedString) and self.compressedString[pos].isdigit(): 
                iterVal += self.compressedString[pos]
                pos += 1
            if len(iterVal) > 0: 
                self.iterationsLeft = int(iterVal)
                self.currentPosition = pos
            else: 
                self.iterationsLeft = 0
                self.currentPosition = len(self.compressedString) - 1
        else: 
            self.currentPosition = len(self.compressedString) - 1
            self.currentChar = ' '


"""
Example 1:

Input
["StringIterator", "next", "next", "next", "next", "next", "next", "hasNext", "next", "hasNext"]
[["L1e2t1C1o1d1e1"], [], [], [], [], [], [], [], [], []]
Output
[null, "L", "e", "e", "t", "C", "o", true, "d", true]

Explanation
StringIterator stringIterator = new StringIterator("L1e2t1C1o1d1e1");
stringIterator.next(); // return "L"
stringIterator.next(); // return "e"
stringIterator.next(); // return "e"
stringIterator.next(); // return "t"
stringIterator.next(); // return "C"
stringIterator.next(); // return "o"
stringIterator.hasNext(); // return True
stringIterator.next(); // return "d"
stringIterator.hasNext(); // return True
"""
def test_string_iterator(): 
    si = StringIterator("L1e2t1C1o1d1e1")
    s = si.next()
    expected = "L"
    assert(s == expected)

    s = si.next()
    expected = "e"
    assert(s == expected)

    s = si.next()
    expected = "e"
    assert(s == expected)

    s = si.next()
    expected = "t"
    assert(s == expected)

    s = si.next()
    expected = "C"
    assert(s == expected)

    s = si.next()
    expected = "o"
    assert(s == expected)

    b = si.hasNext()
    expected = True
    assert(b == expected)

    s = si.next()
    expected = "d"
    assert(s == expected)

    s = si.next()
    expected = "e"
    assert(s == expected)

    b = si.hasNext()
    expected = False
    assert(b == expected)

"""
["StringIterator","next","next","next","hasNext","next","next","next","next","next","next","next","hasNext","next","next","next","next","next","hasNext","next","next","next","next","next","hasNext","next","next","next","next","hasNext","next","next","next","next","next","next","next","next","next","next","next","next","next","next","next","next","next","next","next","hasNext","next","hasNext","next","next","next","next","next","next","hasNext","next","next","next","next","next","next","next","next","next","next","next","next","next","next","hasNext","next","next","next","hasNext","next","next","hasNext","next","next","next","next","next"]

[null,"x","x","x",true,"x","x","x"," "," "," "," ",false," "," "," "," "," ",false," "," "," "," "," ",false," "," "," "," ",false," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," ",false," ",false," "," "," "," "," "," ",false," "," "," "," "," "," "," "," "," "," "," "," "," "," ",false," "," "," ",false," "," ",false," "," "," "," "," "]
"""
def test_case_158(): 
    si = StringIterator("x6")
    s = si.next() 
    expected = "x"
    assert(s == expected)

    s = si.next() 
    expected = "x"
    assert(s == expected)

    s = si.next() 
    expected = "x"
    assert(s == expected)

    b = si.hasNext() 
    expected = True
    assert(b == expected)

    s = si.next() 
    expected = "x"
    assert(s == expected)

    s = si.next() 
    expected = "x"
    assert(s == expected)

    s = si.next() 
    expected = "x"
    assert(s == expected)

    b = si.hasNext() 
    expected = False
    assert(b == expected)

    s = si.next() 
    expected = " "
    assert(s == expected)

    s = si.next() 
    expected = " "
    assert(s == expected)

    s = si.next() 
    expected = " "
    assert(s == expected)

    b = si.hasNext() 
    expected = False
    assert(b == expected)

    s = si.next() 
    expected = " "
    assert(s == expected)

    s = si.next() 
    expected = " "
    assert(s == expected)

    s = si.next() 
    expected = " "
    assert(s == expected)

    b = si.hasNext() 
    expected = False
    assert(b == expected)

    s = si.next() 
    expected = " "
    assert(s == expected)

    s = si.next() 
    expected = " "
    assert(s == expected)

    s = si.next() 
    expected = " "
    assert(s == expected)

    b = si.hasNext() 
    expected = False
    assert(b == expected)


if __name__ == "__main__":
    pytest.main([__file__]) 