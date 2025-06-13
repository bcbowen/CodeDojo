import pytest
from typing import List

class Solution:
    def suggestedProducts(self, products: List[str], searchWord: str) -> List[List[str]]:
        products.sort()
        final_result = [] 
        i = 0; 
        prefix = ""
        while i < len(searchWord): 
            prefix += searchWord[i]
            result = [] 
            for word in products: 
                if word.startswith(prefix): 
                    result.append(word)
                if len(result) == 3: 
                    break
            i += 1
            
            final_result.append(result)
        return final_result
    
"""
class TrieNode: 
    def __init__(self, is_final: bool, val: str): 
        self.children = {}
        self.is_final = is_final
        self.val = val

class Trie: 
    def __init__(self, products: List[str]): 
        self.root = TrieNode(False, "")
    
    def add_word(self, word: str): 
        current = self.root
        for c in word: 
            if not c in current.children: 
                current.children[c] = TrieNode(False, c)
            current = current.children[c]
        c = word[-1]
        current.children[c].is_final = True
        
            

    def lookup(self, chars) -> List[List[str]]:
        results = []
        current = self.root
        for c in chars: 
            if not c in current.children: 
                return results
            current = current.children[c]

        result_stack = [] 
        while current.children: 
            current
        result_stack.append()
        return results

"""

"""
Example 1:
Input: products = ["mobile","mouse","moneypot","monitor","mousepad"], searchWord = "mouse"
Output: [["mobile","moneypot","monitor"],["mobile","moneypot","monitor"],["mouse","mousepad"],["mouse","mousepad"],["mouse","mousepad"]]
Explanation: products sorted lexicographically = ["mobile","moneypot","monitor","mouse","mousepad"].
After typing m and mo all products match and we show user ["mobile","moneypot","monitor"].
After typing mou, mous and mouse the system suggests ["mouse","mousepad"].

Example 2:
Input: products = ["havana"], searchWord = "havana"
Output: [["havana"],["havana"],["havana"],["havana"],["havana"],["havana"]]
Explanation: The only word "havana" will be always suggested while typing the search word.
"""
@pytest.mark.parametrize("products, searchWord, expected", [
    (["mobile","mouse","moneypot","monitor","mousepad"], "mouse", [["mobile","moneypot","monitor"],["mobile","moneypot","monitor"],["mouse","mousepad"],["mouse","mousepad"],["mouse","mousepad"]]), 
    (["havana"], "havana", [["havana"],["havana"],["havana"],["havana"],["havana"],["havana"]])
])
def test_suggestedProducts(products: List[str], searchWord: str, expected: List[List[str]]):
    result = Solution().suggestedProducts(products, searchWord)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])