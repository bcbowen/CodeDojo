import pytest

class MyHashSet:

    @staticmethod
    def get_hash_value(val: int) -> int: 
        return int(val % 1024)

    def __init__(self):
        self.store = {}    

    def add(self, key: int) -> None:
        hash = self.get_hash_value(key)
        if not hash in self.store: 
            self.store[hash] = []
        if not key in self.store[hash]: 
            self.store[hash].append(key)

    def remove(self, key: int) -> None:
        hash = self.get_hash_value(key)
        if hash in self.store: 
            if key in self.store[hash]: 
                self.store[hash].remove(key)
            if len(self.store[hash]) == 0: 
                del self.store[hash]

    def contains(self, key: int) -> bool:
        hash = self.get_hash_value(key)
        if not hash in self.store: 
            return False
        return key in self.store[hash]
"""
Example 1:

Input
["MyHashSet", "add", "add", "contains", "contains", "add", "contains", "remove", "contains"]
[[], [1], [2], [1], [3], [2], [2], [2], [2]]
Output
[null, null, null, true, false, null, true, null, false]

Explanation
MyHashSet myHashSet = new MyHashSet();
myHashSet.add(1);      // set = [1]
myHashSet.add(2);      // set = [1, 2]
myHashSet.contains(1); // return True
myHashSet.contains(3); // return False, (not found)
myHashSet.add(2);      // set = [1, 2]
myHashSet.contains(2); // return True
myHashSet.remove(2);   // set = [1]
myHashSet.contains(2); // return False, (already removed)
"""
def test_1(): 
    hs = MyHashSet()
    hs.add(1)
    hs.add(2)
    result = hs.contains(1)
    expected = True
    assert(result == expected)
    result = hs.contains(3)
    expected = False
    assert(result == expected)
    hs.add(2)
    result = hs.contains(2)
    expected = True
    assert(result == expected)
    hs.remove(2)
    result = hs.contains(2)
    expected = False
    assert(result == expected)
    
# Your MyHashSet object will be instantiated and called as such:
# obj = MyHashSet()
# obj.add(key)
# obj.remove(key)
# param_3 = obj.contains(key)

if __name__ == "__main__":
    pytest.main([__file__]);  