import json
from main import *

run_cases = [
    (["be", "bad", "back", "bat"], "ba", ["bad", "back", "bat"]),
    (["boots", "stoob"], "z", []),
    (["a", "to", "tea", "ted", "ten", "i", "in", "inn"], "i", ["i", "in", "inn"]),
]

submit_cases = run_cases + [
    (["a", "to", "tea", "ted", "ten", "i", "in", "inn"], "te", ["tea", "ted", "ten"]),
]


def test(words, prefix, expected_matches):
    print("---------------------------------")
    print("Trie:")
    trie = Trie()
    for word in words:
        trie.add(word)
    print(json.dumps(trie.root, sort_keys=True, indent=2))
    print(f'Words with prefix: "{prefix}":')
    print(f"Expecting: {expected_matches}")
    try:
        actual = trie.words_with_prefix(prefix)
        print(f"Actual: {actual}")
        if sorted(actual) == sorted(expected_matches):
            print("Pass \n")
            return True
        print("Fail \n")
        return False
    except Exception as e:
        print(f"Error: {e}")
        return False


def main():
    passed = 0
    failed = 0
    for test_case in test_cases:
        correct = test(*test_case)
        if correct:
            passed += 1
        else:
            failed += 1
    if failed == 0:
        print("============= PASS ==============")
    else:
        print("============= FAIL ==============")
    print(f"{passed} passed, {failed} failed")


test_cases = submit_cases
if "__RUN__" in globals():
    test_cases = run_cases

main()
