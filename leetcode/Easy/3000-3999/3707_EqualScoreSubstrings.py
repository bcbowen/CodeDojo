class Solution:
    def scoreBalance(self, s: str) -> bool:
        def get_val(c: str) -> int: 
            return ord(c) - 96
        scores = [0] * len(s)

        scores[0] = get_val(s[0])
        for i in range(1, len(s)): 
            scores[i] = scores[i - 1] + get_val(s[i])
        
        for i in range(len(s)): 
            score = scores[i]
            if scores[-1] - score == score: 
                return True
            
        return False