import pytest
from typing import List
from collections import deque
from collections import defaultdict

class Router:


    def __init__(self, memoryLimit: int):
        self.packetQueue = deque()
        self.memoryLimit = memoryLimit
        self.packetSet = set()
        self.packetLookup = defaultdict(deque)

    def addPacket(self, source: int, destination: int, timestamp: int) -> bool:
        packet = (source, destination, timestamp)
        if packet in self.packetSet:
            return False
        self.packetSet.add(packet)
        self.packetLookup[destination].append(packet)
        if len(self.packetQueue) == self.memoryLimit:
            discard = self.packetQueue.popleft()
            self.packetLookup[discard[destination]].popleft()
        self.packetQueue.append(packet)
        return True

    def forwardPacket(self) -> List[int]:
        if len(self.packetQueue) == 0:
            return []

        packet = self.packetQueue.popleft()
        self.packetSet.remove(packet)
        self.packetLookup[packet[1]].popleft()
        return [packet[0], packet[1], packet[2]]

    """
    def find_start_index(self, startTime: int, endTime: int) -> int:
            if endTime < self.packetQueue[len(self.packetQueue) - 1][2]:
                return -1
            if self.packetQueue[0][2] >= startTime and self.packetQueue[0][2] <= endTime:
                return 0
            i = 0
            j = len(self.packetQueue) - 1
            mid = 0

            while j >= i:
                mid = i + (j - i) // 2
                if self.packetQueue[mid][2] == startTime:
                    if self.packetQueue[mid - 1][2] < startTime:
                        break
                    else:
                        i = mid - 1
                elif self.packetQueue[mid][2] < startTime:
                    i = mid + 1

                else:
                    j = mid - 1
            return mid
    """
    def getCount(self, destination: int, startTime: int, endTime: int) -> int:
        count = 0
        def find_start_index(packets : List[int]) -> int:
            #packets = self.packetLookup[destination]
            if not packets or packets[0] > endTime or packets[-1] < startTime:
                return -1
            elif packets[0] >= startTime and packets[0] <= endTime:
                return 0
            elif packets[-1] >= startTime and packets[-2] < startTime:
                return len(packets) - 1

            start = 0
            end = len(packets) - 1
            while start <= end:
                mid = start + (end - start) // 2
                midTimeStamp = packets[mid][2]
                if midTimeStamp >= startTime and packets[mid - 1][2] < startTime:
                    return mid
                elif midTimeStamp < startTime:
                    start = mid + 1
                else:
                    end = mid - 1
            return mid

        i = find_start_index(self.packetLookup[destination])
        if i == -1:
            return False

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

"""
["Router","addPacket","getCount"]
[[3],[1,4,6],[4,1,4]]
"""

def test_example4():
    r = Router(3)
    r.addPacket(1, 4, 6)
    result = r.getCount(4, 1, 4)
    assert(result == 0)

"""
["Router","addPacket","addPacket","addPacket","getCount"]
[[3],[5,1,1],[5,4,1],[2,5,1],[1,1,1]]

Use Testcase
Output
[null,true,true,true,0]
Expected
[null,true,true,true,1]
"""
def test_case_613():
    r = Router(3)
    r.addPacket(5, 1, 1)
    r.addPacket(5, 4, 1)
    r.addPacket(2, 5, 1)
    result = r.getCount(1, 1, 1)
    assert(result == 1)

"""
@pytest.mark.parametrize("size, packets, startTime, endTime, expected", [
    (3, [(5, 1, 1), (5, 4, 1), (2, 5, 1)], 1, 2, 0),
    (100, [
            (1, 2, 1),
            (1, 2, 2),
            (1, 2, 2),
            (1, 2, 3),
            (1, 2, 3),
            (1, 2, 4)
         ], 3, 5, 3),
    (100, [
            (1, 2, 1),
            (1, 2, 2),
            (1, 2, 2),
            (1, 2, 3),
            (1, 2, 3),
            (1, 2, 4)
         ], 6, 8, -1),
    (100, [
            (1, 2, 6),
            (1, 2, 7),
            (1, 2, 7),
            (1, 2, 8),
            (1, 2, 8),
            (1, 2, 9)
         ], 1, 2, -1)
])
"""

def test_find_start_index(size: int, packets: List[tuple[int, int, int]], startTime: int, endTime: int, expected: int):
    r = Router(size)
    for source, dest, timestamp in packets:
        r.addPacket(source, dest, timestamp)
    result = r.find_start_index(startTime, endTime)
    assert(expected == result)


if __name__ == "__main__":
    pytest.main([__file__])