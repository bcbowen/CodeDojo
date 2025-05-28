class Solution:
    def countSegments(self, s: str) -> int:
        segments = [seg for seg in s.split() ]
        count = 0
        for seg in segments: 
            if seg.strip() != "": 
                count += 1
        return count