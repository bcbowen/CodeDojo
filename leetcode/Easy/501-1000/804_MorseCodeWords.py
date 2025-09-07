from typing import List
import pytest

class Solution:
    def uniqueMorseRepresentations(self, words: List[str]) -> int:
        word_counts = {}
        for word in words: 
            translated = Solution.translate(word)
            if not translated in word_counts: 
                word_counts[translated] = 0
            word_counts[translated] += 1
        return len(word_counts.keys())


    @staticmethod
    def translate(word: str) -> str: 
        codes = [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]   
        a = 97
        result = "" 
        for c in word: 
            index = ord(c) - a
            result += codes[index]
        return result
    
"""
"gin" -> "--...-."
"zen" -> "--...-."
"gig" -> "--...--."
"msg" -> "--...--."
"""
@pytest.mark.parametrize("word, expected", [
    ("gin", "--...-."),
    ("zen", "--...-."), 
    ("gig", "--...--."), 
    ("msg", "--...--.") 
])
def test_translate(word: str, expected: str): 
    result = Solution.translate(word)
    assert(result == expected)

"""
Example 1:
Input: words = ["gin","zen","gig","msg"]
Output: 2
Explanation: The transformation of each word is:
"gin" -> "--...-."
"zen" -> "--...-."
"gig" -> "--...--."
"msg" -> "--...--."
There are 2 different transformations: "--...-." and "--...--.".

Example 2:
Input: words = ["a"]
Output: 1
"""
@pytest.mark.parametrize("words, expected", [
    (["gin","zen","gig","msg"], 2), 
    (["a"], 1)
])
def test_uniqueMorseReps(words: List[str], expected: int): 
    result = Solution().uniqueMorseRepresentations(words)
    assert(expected == result)


if __name__ == "__main__":
    pytest.main([__file__]) 