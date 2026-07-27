class Solution:
    def removeVowels(self, s: str) -> str:
        letters = [] 
        vowels = ['a', 'e', 'i', 'o', 'u']
        for c in s: 
            if not c in vowels: 
                letters.append(c)
        return ''.join(letters)