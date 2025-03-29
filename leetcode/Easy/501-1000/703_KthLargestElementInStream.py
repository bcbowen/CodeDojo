import heapq
import pytest
from typing import List

class KthLargest:
    # min heap with biggest k elements - always has len = k
    # max heap with remaining smaller elements
    # if new element is bigger than smallest element in min heap, move smallest element to max heap and add new element to min heap 
    # if new element is smaller than smallest element in min heap, add it to max heap

    def __init__(self, k: int, nums: List[int]):
        self.big_nums = [] # min heap
        self.small_nums = [-num for num in nums] # max heap
        self.k = k
        heapq.heapify(self.big_nums)
        heapq.heapify(self.small_nums)

        for _ in range(k): 
            if len(self.small_nums) == 0: 
                break
            val = -heapq.heappop(self.small_nums)
            heapq.heappush(self.big_nums, val)

    def add(self, val: int) -> int:
        if len(self.big_nums) < self.k: 
            heapq.heappush(self.big_nums, val)
        elif val > self.big_nums[0]: 
            heapq.heappush(self.small_nums, -heapq.heappop(self.big_nums))
            heapq.heappush(self.big_nums, val)
        else: 
            heapq.heappush(self.small_nums, -val)

        return self.big_nums[0]


# Your KthLargest object will be instantiated and called as such:
# obj = KthLargest(k, nums)
# param_1 = obj.add(val)

"""
Example 1:
Input:
["KthLargest", "add", "add", "add", "add", "add"]
[[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]

Output: [null, 4, 5, 5, 8, 8]

Explanation:

KthLargest kthLargest = new KthLargest(3, [4, 5, 8, 2]);
kthLargest.add(3); // return 4
kthLargest.add(5); // return 5
kthLargest.add(10); // return 5
kthLargest.add(9); // return 8
kthLargest.add(4); // return 8

Example 2:
Input:
["KthLargest", "add", "add", "add", "add"]
[[4, [7, 7, 7, 7, 8, 3]], [2], [10], [9], [9]]

Output: [null, 7, 7, 7, 8]

Explanation:

KthLargest kthLargest = new KthLargest(4, [7, 7, 7, 7, 8, 3]);
kthLargest.add(2); // return 7
kthLargest.add(10); // return 7
kthLargest.add(9); // return 7
kthLargest.add(9); // return 8
 
Ex 3: 
["KthLargest","add","add","add","add","add"]
[[1,[]],[-3],[-2],[-4],[0],[4]]


Ex 4: 
[[2,[0]],[-1],[1],[-2],[-4],[3]]

Use Testcase
Output [null,-1,0,0,0,1]

"""
@pytest.mark.parametrize("k, nums, adds, expected", [
    (3, [4, 5, 8, 2], [3, 5, 10, 9, 4], [4, 5, 5, 8, 8]), 
    (4, [7, 7, 7, 7, 8, 3], [2, 10, 9, 9], [7, 7, 7, 8]), 
    (1, [], [-3, -2, -4, 0, 4], [-3, -2, -2, 0, 4]), 
    (2, [0], [-1, 1, -2, -4, 3], [-1, 0, 0, 0, 1])
])
def test(k: int, nums: List[int], adds: List[int], expected: List[int]): 
    widget = KthLargest(k, nums)
    for i in range(len(adds)): 
        result = widget.add(adds[i]) 
        assert(result == expected[i])

if __name__ == "__main__": 
    pytest.main([__file__])