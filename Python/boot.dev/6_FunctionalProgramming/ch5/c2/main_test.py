from main import *


run_cases = [
    (
        "hello world. this is a test.",
        ["--replace", "--capitalize"],
        [("hello", "hi"), ("world", "earth"), ("test", "test case")],
        "Hi earth. This is a test case.",
    ),
    (
        "hello world. this is a test.",
        ["--capitalize", "--uppercase"],
        [("world", "earth"), ("test", "test case")],
        "Hello WORLD. This is a TEST.",
    ),
    (
        "the quick brown fox jumps over the lazy dog.",
        [],
        [],
        "missing options",
    ),
]


submit_cases = run_cases + [
    (
        "the quick brown fox jumps over the lazy dog.",
        ["--replace", "--lowercase"],
        [],
        "invalid option",
    ),
    (
        "the quick brown fox jumps over the lazy dog.",
        ["--remove", "--capitalize"],
        [("quick", "slow"), ("fox", "wolf"), ("lazy", "active")],
        "The  brown  jumps over the  dog.",
    ),
    (
        "the quick brown fox jumps over the lazy dog",
        ["--replace", "--remove", "--uppercase"],
        [],
        "the quick brown fox jumps over the lazy dog",
    ),
]


def test(filter_cmd, content, options, word_pairs, expected_output):
    print("---------------------------------")
    print(f"Content: {content}")
    print("Options:")
    for option in options:
        print(option)
    print("Word Pairs:")
    for word in word_pairs:
        print(word)
    try:
        result = filter_cmd(content, options, word_pairs)
    except Exception as e:
        result = str(e)
    print(f"Expecting: {expected_output}")
    print(f"   Actual: {result}")
    if result == expected_output:
        print("Pass")
        return True
    print("Fail")
    return False


def main():
    passed = 0
    failed = 0
    print("Filters:")
    for k, v in filters.items():
        print(f"* ({k}, {v.__name__})")
    filter_cmd = get_filter_cmd(filters)
    for test_case in test_cases:
        correct = test(filter_cmd, *test_case)
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
