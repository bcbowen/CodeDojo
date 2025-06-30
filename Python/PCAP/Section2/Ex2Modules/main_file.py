import pytest
import strings_utils

quotes = ['Being happy never goes out of style.',
'Life is either a great adventure or nothing.',
'All you need in this life is ignorance and confidence; then success is sure.',
'All your life, you will be faced with a choice. You can choose love or hate... I choose love.',
'The time is always right to do what is right.']

result = strings_utils.halve_strings(quotes)
print(result)

def test_main(): 
    vals = ["mark", "lydia"]
    expected = [("ma", "rk"), ("lyd", "ia")]
    result =  strings_utils.halve_strings(vals)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 