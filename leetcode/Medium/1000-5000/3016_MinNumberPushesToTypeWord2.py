import pytest

class Solution:
    def minimumPushes(self, word: str) -> int:
        counts = {}
        for c in word: 
            if not c in counts: 
                counts[c] = 0
            counts[c] += 1
        
        counts = dict(sorted(counts.items(), key = lambda item: -item[1]))
        result = 0
        multiplier = 1 
        keynumber = 0
        for _, value in counts.items(): 
            
            keynumber += 1
            if keynumber % 8 == 0: 
                multiplier = keynumber / 8
            else: 
                multiplier = keynumber // 8 + 1

            result += int(value * multiplier)

        return result

        

"""
https://leetcode.com/problems/minimum-number-of-pushes-to-type-word-ii/description/?envType=daily-question&envId=2024-08-06

You are given a string word containing lowercase English letters.

Telephone keypads have keys mapped with distinct collections of lowercase English letters, which can be used to form words by pushing them. 
For example, the key 2 is mapped with ["a","b","c"], we need to push the key one time to type "a", two times to type "b", and three times to type "c" .

It is allowed to remap the keys numbered 2 to 9 to distinct collections of letters. The keys can be remapped to any amount of letters, 
but each letter must be mapped to exactly one key. You need to find the minimum number of times the keys will be pushed to type the string word.

Return the minimum number of pushes needed to type word after remapping the keys.

An example mapping of letters to keys on a telephone keypad is given below. Note that 1, *, #, and 0 do not map to any letters.


Example 1:
Input: word = "abcde"
Output: 5
Explanation: The remapped keypad given in the image provides the minimum cost.
"a" -> one push on key 2
"b" -> one push on key 3
"c" -> one push on key 4
"d" -> one push on key 5
"e" -> one push on key 6
Total cost is 1 + 1 + 1 + 1 + 1 = 5.
It can be shown that no other mapping can provide a lower cost.

Example 2:
Input: word = "xyzxyzxyzxyz"
Output: 12
Explanation: The remapped keypad given in the image provides the minimum cost.
"x" -> one push on key 2
"y" -> one push on key 3
"z" -> one push on key 4
Total cost is 1 * 4 + 1 * 4 + 1 * 4 = 12
It can be shown that no other mapping can provide a lower cost.
Note that the key 9 is not mapped to any letter: it is not necessary to map letters to every key, but to map all the letters.

Example 3:
Input: word = "aabbccddeeffgghhiiiiii"
Output: 24
Explanation: The remapped keypad given in the image provides the minimum cost.
"a" -> one push on key 2
"b" -> one push on key 3
"c" -> one push on key 4
"d" -> one push on key 5
"e" -> one push on key 6
"f" -> one push on key 7
"g" -> one push on key 8
"h" -> two pushes on key 9
"i" -> one push on key 9
Total cost is 1 * 2 + 1 * 2 + 1 * 2 + 1 * 2 + 1 * 2 + 1 * 2 + 1 * 2 + 2 * 2 + 6 * 1 = 24.
It can be shown that no other mapping can provide a lower cost.
"""

@pytest.mark.parametrize("word, expected", [
    ("abcde", 5),
    ("xyzxyzxyzxyz", 12),
    ("aabbccddeeffgghhiiiiii", 24), 
    ("alporfmdqsbhncwyu", 27)
])
def test_minimumPushes(word: str, expected: int):
    result = Solution().minimumPushes(word)
    assert result == expected

if __name__ == "__main__":
    pytest.main([__file__])