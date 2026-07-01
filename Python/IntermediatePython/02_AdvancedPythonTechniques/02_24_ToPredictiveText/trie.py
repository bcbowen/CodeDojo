from typing import List
import pytest

class trie_node: 
    def __init__(self, val = None):
        self.val = val
        self.children = {}

    def add(self, val: str): 
        if len(val) == 0: 
            self.children['$'] = trie_node('$')
            return  
        if not val[0] in self.children: 
            self.children[val[0]] = trie_node(val[0])

        child = self.children[val[0]]
        child.add(val[1:])


    def exists(self, val: str): 
        if not val: 
            return False
        search = val
        node = self
        while search: 
            if not search[0] in node.children: 
                return False
            node = node.children[search[0]]
            search = search[1:]
        if not '$' in node.children: 
            return False

        return True         
        

def test_init_trie_node(): 
    node = trie_node()
    assert(node)

    assert(node.val == None)

def test_add_word(): 
    node = trie_node()
    node.add('do')
    assert('d' in node.children)
    node = node.children['d']
    assert('o' in node.children)
    node = node.children['o']
    assert('$' in node.children)

"""
Add whold word and check if it is found. 
"""
def test_whole_word_exists(): 
    node = trie_node() 
    word = 'does'
    node.add(word)
    assert(node.exists(word))

"""
This word does exist but is not flagged as a word (no terminator)
"""
def test_partial_word_does_not_exist(): 
    node = trie_node() 
    word = 'does'
    partial = 'do'
    node.add(word)
    assert(not node.exists(partial))

"""
Add word, then add word that is part of the original word. 
The partial (2nd) word will not exist before adding it explicitly, but then it will be found
"""
def test_add_partial_word_to_existing_word(): 
    node = trie_node() 
    word = 'does'
    partial = 'do'
    node.add(word)
    assert(not node.exists(partial))
    node.add(partial)
    assert(node.exists(partial))

def test_multi_words_same_root(): 
    node = trie_node() 
    node.add('does')
    node.add('dope')
    node.add('docker')
    node.add('doctor')
    node = node.children['d']
    node = node.children['o']
    assert('e' in node.children)
    assert('p' in node.children)
    assert('c' in node.children)

def test_multi_children_at_root(): 
    node = trie_node() 
    node.add('apple')
    node.add('banana')
    node.add('coconut')
    node.add('a')
    node.add('xylophone')
    assert('a' in node.children)
    assert('$' in node.children['a'].children) 
    assert('x' in node.children)

    assert(node.exists('banana'))

if __name__ == "__main__":
    pytest.main([__file__])