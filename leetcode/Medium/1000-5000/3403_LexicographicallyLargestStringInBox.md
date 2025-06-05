# Intuition
The lexicographically largest string must start with the largest char in the string. We can 
skip a lot of processing by only considering strings that start with the largest character. 

The max length for a string, if numFriends > 1 is the length of the word - numFriends + 1. 

When we know the max char, we can find all instances of that char in the string and find the largest word 
that can be created from each position, either max len or to the end of the word. 

# Approach
Find the max char in the word. 
Once we have the max char, find the indexes where it occurs. 
From each index, find the max word that can be created from that position
Sort the words and return the one that is the largest

# Complexity
- Time complexity:
<!-- Add your time complexity here, e.g. $$O(n)$$ -->
$$O(n LOG n)$$ because of the sort at the end

- Space complexity:
<!-- Add your space complexity here, e.g. $$O(n)$$ -->
$$O(n)$$: We store the indexes of the max char and the larges word that can be created from each index

# Code
```python3 []
class Solution:
    def answerString(self, word: str, numFriends: int) -> str:
        if numFriends == 1: 
            return word
        
        max_char = word[0]
        max_len = len(word) - numFriends + 1
        for i in range(len(word)): 
            if word[i] > max_char: 
                max_char = word[i]
        max_char_indexes = [] 
        for i in range(len(word)): 
            if word[i] == max_char: 
                max_char_indexes.append(i)
        sections = [] 
        for i in max_char_indexes: 
            if i + max_len > len(word): 
                sections.append(word[i:])
            else:
                sections.append(word[i:i + max_len])
        sections.sort()
        return sections[-1]
```