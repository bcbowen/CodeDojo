class Solution:
    def checkRecord(self, s: str) -> bool:
        consecutive_late_count = 0
        absent_count = 0
        for c in s: 
            match c: 
                case 'L': 
                    consecutive_late_count += 1
                case 'A': 
                    consecutive_late_count = 0
                    absent_count += 1
                case _: 
                    consecutive_late_count = 0
            if consecutive_late_count == 3 or absent_count == 2: 
                return False
        return True