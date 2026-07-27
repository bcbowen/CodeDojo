class Solution:
    def calculateTime(self, keyboard: str, word: str) -> int:
        keymap = {}
        dist = 0
        for i in range(26): 
            keymap[keyboard[i]] = i
        
        dist += keymap[word[0]]
        for i in range(1, len(word)): 
            dist += abs(keymap[word[i - 1]] - keymap[word[i]])

        return dist