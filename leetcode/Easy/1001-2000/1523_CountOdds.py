class Solution:
    # 1 2 3 4 5 6 7 8 9
    # 1 - 9: 5 ((hi - low) // 2 + 1)
    # 1 - 8: 4 ((hi - low) // 2 + 1)
    # 2 - 8: 3 (hi // 2)
    def countOdds(self, low: int, high: int) -> int:
        odd_params = 0 if low % 2 == 0 else 1
        if high % 2 == 1: 
            odd_params += 1

        offset = 0 if odd_params == 0 else 1
        
        return (high - low) // 2 + offset