import pytest
#import re

def get_longest_word(phrase): 
    #pattern = r"\S*"
    words = phrase.replace(',', ' ').replace('.', ' ').replace('\n', '').split(' ')
    max_len, max_word = 0, ''
    for word in words: 
        if len(word) > max_len: 
            max_len = len(word)
            max_word = word

    return max_word

"""
Once I'm awake, I'll sacrifice your soul to the ruler of darkness.

'''
Once upon a time, there was a beginner programmer named Alice who was eager to learn Python. She tried to learn from books, but found it difficult to grasp the concepts. One day, she stumbled upon an online course.

Alice was thrilled. The course was taught by a well-known programmer who made the lessons interesting and easy to understand. The course covered everything a beginner programmer needed, and Alice was finally able to understand how to code in Python.
'''

"""
@pytest.mark.parametrize("phrase, expected", [
    ("Once I'm awake, I'll sacrifice your soul to the ruler of darkness.", "sacrifice"), 
    ('''
Once upon a time, there was a beginner programmer named Alice who was eager to learn Python. She tried to learn from books, but found it difficult to grasp the concepts. One day, she stumbled upon an online course.

Alice was thrilled. The course was taught by a well-known programmer who made the lessons interesting and easy to understand. The course covered everything a beginner programmer needed, and Alice was finally able to understand how to code in Python.
''', "interesting"), 
    ('aaa,bbbb', 'bbbb')
])
def test(phrase: str, expected: bool): 
    result = get_longest_word(phrase)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])