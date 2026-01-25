from collections import Counter

class Solution:
    def majorityFrequencyGroup(self, s: str) -> str:
        char_counts = Counter(s)
        freq_counts = [''] * (len(s) + 1)
        max_count = -1
        max_len = -1
        for char, val in char_counts.items(): 
            freq_counts[val] += char
            if len(freq_counts[val]) > max_len or (len(freq_counts[val]) == max_len and val > max_count): 
                max_count = val
                max_len = len(freq_counts[val])
        return freq_counts[max_count]        