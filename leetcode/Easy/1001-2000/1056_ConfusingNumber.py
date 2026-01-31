class Solution:
    def confusingNumber(self, n: int) -> bool:
        replacements = {0: 0, 1: 1, 6: 9, 8: 8, 9: 6}
        start = n
        replacement = ''
        while start > 0: 
            val = start % 10
            if not val in replacements: 
                return False
            new_val = replacements[val]
            replacement += str(new_val)
            start //= 10

        return n != int(replacement) 
    
    # 916 -> 916