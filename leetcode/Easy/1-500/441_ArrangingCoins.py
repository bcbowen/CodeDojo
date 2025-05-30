class Solution:
    def arrangeCoins(self, n: int) -> int:
        step_len = 0
        complete_rows = 0
        while n > step_len:
            step_len += 1
            n -= step_len
            complete_rows += 1
        return complete_rows 
