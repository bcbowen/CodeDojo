import pytest
from typing import List
from collections import defaultdict

class Solution:
    def areSentencesSimilar(self, sentence1: List[str], sentence2: List[str], similarPairs: List[List[str]]) -> bool:
        if len(sentence1) != len(sentence2): 
            return False
        
        lookup = defaultdict(list[str])
        for pair in similarPairs: 
            lookup[pair[0]].append(pair[1])
            lookup[pair[1]].append(pair[0])
        
        for i in range(len(sentence1)): 
            if sentence1[i] != sentence2[i] and sentence2[i] not in lookup[sentence1[i]]: 
                return False
        return True
    
"""
Example 1:
Input: sentence1 = ["great","acting","skills"], sentence2 = ["fine","drama","talent"], similarPairs = [["great","fine"],["drama","acting"],["skills","talent"]]
Output: true
Explanation: The two sentences have the same length and each word i of sentence1 is also similar to the corresponding word in sentence2.

Example 2:
Input: sentence1 = ["great"], sentence2 = ["great"], similarPairs = []
Output: true
Explanation: A word is similar to itself.

Example 3:
Input: sentence1 = ["great"], sentence2 = ["doubleplus","good"], similarPairs = [["great","doubleplus"]]
Output: false
Explanation: As they don't have the same length, we return false.

"""
@pytest.mark.parametrize("sentence1, sentence2, similarPairs, expected", [
    (["great","acting","skills"], ["fine","drama","talent"], [["great","fine"],["drama","acting"],["skills","talent"]], True), 
    (["great"], ["great"], [], True), 
    (["great"], ["doubleplus","good"],  [["great","doubleplus"]], False)
])
def test_areSentencesSimilar(sentence1: List[str], sentence2: List[str], similarPairs: List[List[str]], expected: bool):
    result = Solution().areSentencesSimilar(sentence1, sentence2, similarPairs)
    assert(result == expected)

def test_case_34(): 
    sentence1 = ["an","extraordinary","meal"]
    sentence2 = ["one","good","dinner"]
    pairs = [["great","good"],["extraordinary","good"],["well","good"],["wonderful","good"],["excellent","good"],["fine","good"],["nice","good"],["any","one"],["some","one"],["unique","one"],["the","one"],["an","one"],["single","one"],["a","one"],["truck","car"],["wagon","car"],["automobile","car"],["auto","car"],["vehicle","car"],["entertain","have"],["drink","have"],["eat","have"],["take","have"],["fruits","meal"],["brunch","meal"],["breakfast","meal"],["food","meal"],["dinner","meal"],["super","meal"],["lunch","meal"],["possess","own"],["keep","own"],["have","own"],["extremely","very"],["actually","very"],["really","very"],["super","very"]]
    result = Solution().areSentencesSimilar(sentence1, sentence2, pairs)
    expected = True

    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])