import pytest
from typing import List
from collections import deque

class Router:


    def __init__(self, memoryLimit: int):
        self.packetQueue = deque()
        self.memoryLimit = memoryLimit
        self.packetSet = set()

    def addPacket(self, source: int, destination: int, timestamp: int) -> bool:
        packet = (source, destination, timestamp)
        if packet in self.packetSet: 
            return False 
        self.packetSet.add(packet)
        if len(self.packetQueue) == self.memoryLimit: 
            self.packetQueue.popleft()
        self.packetQueue.append(packet)
        return True

    def forwardPacket(self) -> List[int]:
        if len(self.packetQueue) == 0: 
            return [] 
        
        packet = self.packetQueue.popleft()
        self.packetSet.remove(packet) 
        return [packet[0], packet[1], packet[2]]
        

    def getCount(self, destination: int, startTime: int, endTime: int) -> int:
        count = 0
        def find_start_index(): 
            i = 0
            j = len(self.packetQueue) - 1
            mid = 0
            while j >= i: 
                mid = i + (j - i) // 2 
                if self.packetQueue[mid][2] == startTime: 
                    break
                elif self.packetQueue[mid][2] < startTime: 
                    i = mid + 1
                
                else: 
                    j = mid - i
            return mid
        
        i = find_start_index()
        for j in range(i, len(self.packetQueue)): 
            packet = self.packetQueue[j]
            packetTime = packet[2]
            if packetTime > endTime: 
                break
            if packetTime >= startTime and packet[1] == destination: 
                count += 1
        return count


# Your Router object will be instantiated and called as such:
# obj = Router(memoryLimit)
# param_1 = obj.addPacket(source,destination,timestamp)
# param_2 = obj.forwardPacket()
# param_3 = obj.getCount(destination,startTime,endTime)

"""
Example 1:

Input:
["Router", "addPacket", "addPacket", "addPacket", "addPacket", "addPacket", "forwardPacket", "addPacket", "getCount"]

[[3], [1, 4, 90], [2, 5, 90], [1, 4, 90], [3, 5, 95], [4, 5, 105], [], [5, 2, 110], [5, 100, 110]]

Output:
[null, true, true, false, true, true, [2, 5, 90], true, 1] 

Explanation

Router router = new Router(3); // Initialize Router with memoryLimit of 3.
router.addPacket(1, 4, 90); // Packet is added. Return True.
router.addPacket(2, 5, 90); // Packet is added. Return True.
router.addPacket(1, 4, 90); // This is a duplicate packet. Return False.
router.addPacket(3, 5, 95); // Packet is added. Return True
router.addPacket(4, 5, 105); // Packet is added, [1, 4, 90] is removed as number of packets exceeds memoryLimit. Return True.
router.forwardPacket(); // Return [2, 5, 90] and remove it from router.
router.addPacket(5, 2, 110); // Packet is added. Return True.
router.getCount(5, 100, 110); // The only packet with destination 5 and timestamp in the inclusive range [100, 110] is [4, 5, 105]. Return 1.
"""

def test_example1():
    r = Router(3)
    result = r.addPacket(1, 4, 90)
    assert(result == True)

    result = r.addPacket(2, 5, 90)
    assert(result == True)

    result = r.addPacket(1, 4, 90)
    assert(result == False)

    result = r.addPacket(3, 5, 95)
    assert(result == True)

    result = r.addPacket(4, 5, 105)
    assert(result == True)

    r.forwardPacket()

    result = r.addPacket(5, 2, 110)
    assert(result == True)

    result = r.getCount(5, 100, 110)
    assert(result == 1)
    
"""

Example 2:

Input:
["Router", "addPacket", "forwardPacket", "forwardPacket"]

[[2], [7, 4, 90], [], []]

Output:
[null, true, [7, 4, 90], []] 

Explanation

Router router = new Router(2); // Initialize Router with memoryLimit of 2.
router.addPacket(7, 4, 90); // Return True.
router.forwardPacket(); // Return [7, 4, 90].
router.forwardPacket(); // There are no packets left, return [].
"""

def test_example2(): 
    r = Router(2)
    result = r.addPacket(7, 4, 90)
    assert(result == True)

    result = r.forwardPacket()
    assert(result == [7, 4, 90])

    result = r.forwardPacket() 
    assert(result == [])

"""
["Router","addPacket","getCount","forwardPacket","getCount","addPacket","getCount"]
[[5],[4,2,1],[2,1,1],[],[2,1,1],[4,2,1],[2,1,1]]
Output:
[null,true,1,[4,2,1],0,false,0]
Expected:
[null,true,1,[4,2,1],0,true,1]
"""

def test_example3(): 
    r = Router(5)
    result = r.addPacket(4, 2, 1)
    assert(result == True)

    result = r.getCount(2, 1, 1)
    assert(result == 1)

    result = r.forwardPacket() 
    assert(result == [4, 2, 1])

    result = r.getCount(2, 1, 1)
    assert(result == 0)

    result = r.addPacket(4, 2, 1)
    assert(result == True)

    result = r.getCount(2, 1, 1)
    assert(result == 1)

if __name__ == "__main__":
    pytest.main([__file__]) 