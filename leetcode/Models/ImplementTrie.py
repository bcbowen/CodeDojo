import pytest

class Trie:

    def __init__(self):
        self.root = TrieNode(False, "")

    def insert(self, word: str) -> None:
        current = self.root
        for c in word: 
            if not c in current.children: 
                current.children[c] = TrieNode(False, c)
            current = current.children[c]
        current.is_final = True

    def search(self, word: str) -> bool:
        current = self.root
        for c in word: 
            if not c in current.children: 
                return False
            current = current.children[c]
        return current.is_final
        

    def startsWith(self, prefix: str) -> bool:
        current = self.root
        for c in prefix: 
            if not c in current.children: 
                return False
            current = current.children[c]
        return True
    
        
class TrieNode: 
    def __init__(self, is_final: bool, val: str):
        self.is_final = is_final
        self.val = val
        self.children = {}



# Your Trie object will be instantiated and called as such:
# obj = Trie()
# obj.insert(word)
# param_2 = obj.search(word)
# param_3 = obj.startsWith(prefix)

"""
Input
["Trie", "insert", "search", "search", "startsWith", "insert", "search"]
[[], ["apple"], ["apple"], ["app"], ["app"], ["app"], ["app"]]
Output
[null, null, true, false, true, null, true]

Explanation
Trie trie = new Trie();
trie.insert("apple");
trie.search("apple");   // return True
trie.search("app");     // return False
trie.startsWith("app"); // return True
trie.insert("app");
trie.search("app");     // return True
"""

def test_Trie(): 
    trie = Trie()
    trie.insert("apple")
    result = trie.search("apple")
    expected = True
    assert(result == expected)
    result = trie.search("app")
    expected = False 
    assert(result == expected)
    result = trie.startsWith("app")
    expected = True
    assert(result == expected)
    trie.insert("app")    
    result = trie.search("app")
    expected = True 
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 