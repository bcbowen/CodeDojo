from typing import List 

class Solution:
    def fairCandySwap(self, aliceSizes: List[int], bobSizes: List[int]) -> List[int]:
        alice_sum, bob_sum = sum(aliceSizes), sum(bobSizes)
        bob_set = set(bobSizes)
        for alice_candy in aliceSizes: 
            if alice_candy + (bob_sum - alice_sum) // 2 in bob_set: 
                return [alice_candy, alice_candy + (bob_sum - alice_sum) // 2]   