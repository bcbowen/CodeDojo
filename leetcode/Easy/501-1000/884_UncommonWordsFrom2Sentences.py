from collections import Counter
from typing import List


class Solution:
    def uncommonFromSentences(self, s1: str, s2: str) -> List[str]:
        result = [] 

        counter1 = Counter(s1.split(' '))
        counter2 = Counter(s2.split(' '))

        for item in counter1.items(): 
            if item[1] == 1 and not item[0] in counter2: 
                result.append(item[0])

        for item in counter2.items(): 
            if item[1] == 1 and not item[0] in counter1: 
                result.append(item[0])
        return result

