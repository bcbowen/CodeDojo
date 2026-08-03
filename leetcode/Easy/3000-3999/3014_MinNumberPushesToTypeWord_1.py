import pytest

class Solution:
    def minimumPushes(self, word: str) -> int:
        multiplier = 1
        valid_digits = 8
        to_map = len(word)
        press_count = 0

        while to_map > 0: 
            if to_map > valid_digits: 
                press_count += (valid_digits * multiplier)
                to_map -= valid_digits
                multiplier += 1
            else: 
                press_count += (to_map * multiplier)
                to_map = 0
            

        return press_count


if __name__ == "__main__": 
    pytest.main([__file__])