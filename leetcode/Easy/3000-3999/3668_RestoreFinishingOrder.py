from typing import List

class Solution:
    def recoverOrder(self, order: List[int], friends: List[int]) -> List[int]:
        friend_set = set(friends)
        result = [] 
        for f in order: 
            if f in friend_set: 
                result.append(f)
        return result