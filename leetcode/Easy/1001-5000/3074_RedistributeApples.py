from typing import List

class Solution:
    def minimumBoxes(self, apple: List[int], capacity: List[int]) -> int:
        capacity.sort(reverse=True)
        appleCount = sum(apple) 
        box_count = 1
        for box in capacity: 
            appleCount -= box
            if appleCount <= 0: 
                break
            box_count += 1
        return box_count
