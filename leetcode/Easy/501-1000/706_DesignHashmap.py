import pytest 

class MyHashMap:

    # each entry: [(key, val)]
    def __init__(self):
        self._map = [[] for _ in range(1024)]

    def put(self, key: int, value: int) -> None:
        hash = self.__get_hash__(key)
        vals = self._map[hash]
        for index, entry in enumerate(vals): 
            k, _ = entry
            if k == key: 
                vals[index] = (k, value)
                return 
        self._map[hash].append((key, value))

    def get(self, key: int) -> int:
        val = -1
        hash = self.__get_hash__(key)
        vals = self._map[hash]
        for k, v in vals: 
            if k == key: 
               val = v
               break 
        return val

    def remove(self, key: int) -> None:
        hash = self.__get_hash__(key)
        vals = self._map[hash]
        for index, entry in enumerate(vals): 
            k, _ = entry
            if k == key: 
                del vals[index] 
                return 
        
    
    def __get_hash__(self, key: int) -> int: 
        return key % 1024

# Your MyHashMap object will be instantiated and called as such:
# obj = MyHashMap()
# obj.put(key,value)
# param_2 = obj.get(key)
# obj.remove(key)

"""
Example 1:

Input
["MyHashMap", "put", "put", "get", "get", "put", "get", "remove", "get"]
[[], [1, 1], [2, 2], [1], [3], [2, 1], [2], [2], [2]]
Output
[null, null, null, 1, -1, null, 1, null, -1]

Explanation
MyHashMap myHashMap = new MyHashMap();
myHashMap.put(1, 1); // The map is now [[1,1]]
myHashMap.put(2, 2); // The map is now [[1,1], [2,2]]
myHashMap.get(1);    // return 1, The map is now [[1,1], [2,2]]
myHashMap.get(3);    // return -1 (i.e., not found), The map is now [[1,1], [2,2]]
myHashMap.put(2, 1); // The map is now [[1,1], [2,1]] (i.e., update the existing value)
myHashMap.get(2);    // return 1, The map is now [[1,1], [2,1]]
myHashMap.remove(2); // remove the mapping for 2, The map is now [[1,1]]
myHashMap.get(2);    // return -1 (i.e., not found), The map is now [[1,1]]
 
"""
def test_hashmap():
    hm = MyHashMap()
    assert(len(hm._map) == 1024)
    hm.put(1, 1)
    hm.put(2, 2)
    result = hm.get(1)
    expected = 1
    assert(result == expected)
    result = hm.get(3)
    expected = -1
    assert(result == expected)
    result = hm.get(2)
    expected = 2
    assert(result == expected)
    hm.put(2, 1)
    result = hm.get(2)
    expected = 1
    assert(result == expected)
    hm.remove(2)
    result = hm.get(2)
    expected = -1
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])