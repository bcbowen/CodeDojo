import helper
import gold
import pytest

from pathlib import Path
from trie import trie_node


def parse_content(content):
    result = {}
    lines = content.split('\n')
    for line in lines: 
        line = line.strip()
        fields = line.split()
        result[fields[0]] = int(fields[1])
    return result

def make_tree(words) -> trie_node:
    node = trie_node()
    word_list = [word for word in words.keys()]
    for word in word_list: 
        node.add(word)

    return node

def predict(tree, numbers):
    return {}

def get_test_content(): 
    return """the 6
    of  4
    and 2"""

def test_parse_content(): 
    content = get_test_content()
    result = parse_content(content)
    assert("the" in result)
    assert(result["the"] == 6)
    assert("of" in result)
    assert(result["of"] == 4)
    assert("and" in result)
    assert(result["and"] == 2)

def test_make_tree(): 
    content = get_test_content()
    words = parse_content(content)
    trie = make_tree(words)
    assert(trie.exists("the"))

if __name__ == '__main__':
    pytest.main([__file__])

    script_dir = Path(__file__).parent
    filepath = script_dir / 'ngrams-10k.txt'
    content = helper.read_content(filename=str(filepath))

    # When you've finished implementing a part, remove the `gold.` prefix to check your own code.

    # PART 1: Parsing a string into a dictionary.
    #words = gold.parse_content(content)
    words = parse_content(content)
    
    
    # PART 2: Building a trie from a collection of words.
    tree = make_tree(words)
"""
    while True:
        # PART 3: Predict words that could follow
        numbers = helper.ask_for_numbers()
        predictions = gold.predict(tree, numbers)

        if not predictions:
            print('No words were found that match those numbers. :(')
        else:
            for prediction, frequency in predictions[:10]:
                print(prediction, frequency)

        response = input('Want to go again? [y/N] ')
        again = response and response[0] in ('y', 'Y')
        if not again:
            break

    """
    