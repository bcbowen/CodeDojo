import pytest
from collections import deque

class Solution:
    def minMutation(self, startGene: str, endGene: str, bank: list[str]) -> int:
        if not bank: 
            return -1
        seen = {(startGene)}
        chars = "ACGT"
        queue = deque([(startGene, 0)])
                
        while queue: 
            gene, count = queue.popleft()

            if gene == endGene: 
                return count
            
            for c in chars: 
                for i in range(len(gene)): 
                    if c != gene[i]: 
                        new_gene = gene[0:i] + c + gene[i+1:]
                        if new_gene in bank and new_gene not in seen: 
                            seen.add(new_gene)
                            queue.append((new_gene, count + 1))
        return -1

"""
Example 1:
Input: startGene = "AACCGGTT", endGene = "AACCGGTA", bank = ["AACCGGTA"]
Output: 1

Example 2:
Input: startGene = "AACCGGTT", endGene = "AAACGGTA", bank = ["AACCGGTA","AACCGCTA","AAACGGTA"]
Output: 2

"AACCGGTT"; endGene = "AACCGCTA"; bank = ["AACCGGTA","AACCGCTA","AAACGGTA"]; Expected: 2

"""
@pytest.mark.parametrize("startGene, endGene, bank, expected", [
    ("AACCGGTT", "AACCGGTA", ["AACCGGTA"], 1), 
    ("AACCGGTT", "AAACGGTA", ["AACCGGTA","AACCGCTA","AAACGGTA"], 2), 
    ("AACCGGTT", "AACCGGTA", [], -1), 
    ("AACCGGTT", "AACCGCTA", ["AACCGGTA","AACCGCTA","AAACGGTA"], 2)
])
def test_minMutation(startGene: str, endGene: str, bank: list[str], expected: int):
    result = Solution().minMutation(startGene, endGene, bank)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])