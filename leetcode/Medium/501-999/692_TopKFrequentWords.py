import pytest
import heapq
from collections import Counter
from typing import List

class Solution:
    def topKFrequent(self, words: List[str], k: int) -> List[str]:
        word_counts = Counter(words)
        word_heap = [(-freq, word) for word, freq in word_counts.items()]
        heapq.heapify(word_heap)
        result = [] 
        for _ in range(k):
            result.append(heapq.heappop(word_heap)[1])
        
        return result

"""
Example 1:
Input: words = ["i","love","leetcode","i","love","coding"], k = 2
Output: ["i","love"]
Explanation: "i" and "love" are the two most frequent words.
Note that "i" comes before "love" due to a lower alphabetical order.

Example 2:
Input: words = ["the","day","is","sunny","the","the","the","sunny","is","is"], k = 4
Output: ["the","is","sunny","day"]
Explanation: "the", "is", "sunny" and "day" are the four most frequent words, with the number of occurrence being 4, 3, 2 and 1 respectively.
"""
@pytest.mark.parametrize("words, k, expected", [
    (["i","love","leetcode","i","love","coding"], 2, ["i","love"]), 
    (["the","day","is","sunny","the","the","the","sunny","is","is"], 4, ["the","is","sunny","day"])
])
def test_topKFrequent(words: List[str], k: int, expected: List[str]):
    result = Solution().topKFrequent(words, k)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 