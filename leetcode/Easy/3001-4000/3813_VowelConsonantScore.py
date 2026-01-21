class Solution:
    def vowelConsonantScore(self, s: str) -> int:
        vowels = ['a', 'e', 'i', 'o', 'u']
        v = 0
        c = 0
        for l in s: 
            if l in vowels: 
                v += 1
            elif l == ' ' or l.isdigit():
                continue
            else: 
                c += 1
        if c == 0: 
            return 0
        else:
            return v // c