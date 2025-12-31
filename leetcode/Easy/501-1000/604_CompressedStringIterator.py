import pytest
import re
from collections import deque
from typing import List, Tuple

"""
Parse compressedString to a queue of tuples with a letter and number of repititions. 
"""
class StringIterator:

    def __init__(self, compressedString: str):
        self.chars = StringIterator.parse(compressedString)

    @staticmethod
    def parse(val: str) -> deque[Tuple[str, int]]: 
        pattern = r"([A-Za-z])(\d+)"
        result = [(m[0], int(m[1])) for m in re.findall(pattern, val)]
        
        return deque(result)

    def next(self) -> str:
        if len(self.chars) == 0:
            return ' '

        if self.chars[0][1] == 0: 
            self.chars.popleft()
            return self.next() 

        letter, length = self.chars[0]
        self.chars[0] = (letter, length - 1)

        return letter


    def hasNext(self) -> bool:
        if len(self.chars) == 0: 
            return False
        elif len(self.chars) > 1: 
            return True
        else: 
            return self.chars[0][1] > 0

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

@pytest.mark.parametrize("val, expected", [
    ('a1b2c3', deque([('a', 1), ('b', 2), ('c', 3)])),
    ('a10b234c3443', deque([('a', 10), ('b', 234), ('c', 3443)]))
])
def test_parse(val: str, expected: deque[Tuple[str, int]]): 
    result = StringIterator.parse(val)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 