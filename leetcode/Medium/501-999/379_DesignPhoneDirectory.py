import pytest

class PhoneDirectory:

    def __init__(self, maxNumbers: int):
        self._next = 0
        self._directory = [True] * maxNumbers
        self._released = []

    def get(self) -> int:
        next = -1
        if self._next == len(self._directory): 
            if len(self._released) > 0: 
                next = self._released.pop()
                self._directory[next] = False
        else: 
            next = self._next
            self._next += 1
            self._directory[next] = False
            return next
        return next

    def check(self, number: int) -> bool:
        if number < 0 or number >= len(self._directory): 
            return False
        return self._directory[number]

    def release(self, number: int) -> None:
        if not self.check(number): 
            self._released.append(number)
            self._directory[number] = True


# Your PhoneDirectory object will be instantiated and called as such:
# obj = PhoneDirectory(maxNumbers)
# param_1 = obj.get()
# param_2 = obj.check(number)
# obj.release(number)
"""
Example 1:

Input
["PhoneDirectory", "get", "get", "check", "get", "check", "release", "check"]
[[3], [], [], [2], [], [2], [2], [2]]
Output
[null, 0, 1, true, 2, false, null, true]

Explanation
PhoneDirectory phoneDirectory = new PhoneDirectory(3);
phoneDirectory.get();      // It can return any available phone number. Here we assume it returns 0.
phoneDirectory.get();      // Assume it returns 1.
phoneDirectory.check(2);   // The number 2 is available, so return true.
phoneDirectory.get();      // It returns 2, the only number that is left.
phoneDirectory.check(2);   // The number 2 is no longer available, so return false.
phoneDirectory.release(2); // Release number 2 back to the pool.
phoneDirectory.check(2);   // Number 2 is available again, return true.
"""
def test(): 
    d = PhoneDirectory(3)
    val = d.get() 
    expected = 0  
    assert(val == expected)

    val = d.get() 
    expected = 1
    assert(val == expected)

    is_available = d.check(2)
    expected = True
    assert(is_available == expected)

    val = d.get() 
    expected = 2
    assert(val == expected)

    is_available = d.check(2)
    expected = False
    assert(is_available == expected)

    d.release(2)

    is_available = d.check(2)
    expected = True
    assert(is_available == expected)


"""
TC 8: 
["PhoneDirectory","get","get","check","check","check","get","check","check","check","release","check","get","check"]
[[3],[],[],[0],[1],[2],[],[0],[1],[2],[2],[2],[],[2]]

Use Testcase
Output
[null,0,1,false,false,true,2,false,false,false,null,true,2,true]
Expected
[null,0,1,false,false,true,2,false,false,false,null,true,2,false]
"""

def test_TC8(): 
    d = PhoneDirectory(3)
    val = d.get() 
    expected = 0
    assert(val == expected) 

    val = d.get() 
    expected = 1
    assert(val == expected) 

    val = d.check(0)
    expected = False
    assert(val == expected) 

    val = d.check(1)
    expected = False
    assert(val == expected) 

    val = d.check(2)
    expected = True
    assert(val == expected) 

    val = d.get() 
    expected = 2
    assert(val == expected) 

    val = d.check(0)
    expected = False
    assert(val == expected) 

    val = d.check(1)
    expected = False
    assert(val == expected) 

    val = d.check(2)
    expected = False
    assert(val == expected) 

    d.release(2)

    val = d.check(2)
    expected = True
    assert(val == expected) 

    val = d.get() 
    expected = 2
    assert(val == expected) 

    val = d.check(2)
    expected = False
    assert(val == expected) 

"""
TC 11
["PhoneDirectory","check","get","get","release","check","get","get","check","get","check","check","get","release","check","check"]
[[3],[2],[],[],[2],[1],[],[],[0],[],[1],[2],[],[1],[1],[0]]

Use Testcase
Output
[null,true,0,1,null,false,2,2,false,-1,false,false,-1,null,true,false]
Expected
[null,true,0,1,null,false,2,-1,false,-1,false,false,-1,null,true,false]

"""
def test_TC11(): 
    d = PhoneDirectory(3)
    result = d.check(2)
    expected = True
    assert(result == expected)

    result = d.get()
    expected = 0
    assert(result == expected)

    result = d.get()
    expected = 1
    assert(result == expected)

    d.release(2)

    result = d.check(1)
    expected = False
    assert(result == expected)

    result = d.get()
    expected = 2
    assert(result == expected)

    result = d.get()
    expected = -1
    assert(result == expected)

    result = d.check(0)
    expected = False
    assert(result == expected)

    result = d.get()
    expected = -1
    assert(result == expected)

    result = d.check(1)
    expected = False
    assert(result == expected)

    result = d.check(2)
    expected = False
    assert(result == expected)

    result = d.get()
    expected = -1
    assert(result == expected)

    d.release(1)

    result = d.check(1)
    expected = True
    assert(result == expected)

    result = d.check(2)
    expected = False
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])