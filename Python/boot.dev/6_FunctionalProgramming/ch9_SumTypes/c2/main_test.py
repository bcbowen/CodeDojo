from main import *

try:
    (EditType.SUBSTITUTE and EditType.INSERT and EditType.DELETE and EditType.NEWLINE)
except Exception as error:
    print(f"Error: Missing attribute {error} from enum")

    class EditType(Enum):
        SUBSTITUTE = None
        DELETE = None
        DELETE = None
        NEWLINE = None


run_cases = [
    (
        """Dear Manager,

I’m outraged!
My car warranty is
an total disaster.
Fix this immediately now!

Sincerely,""",
        EditType.SUBSTITUTE,
        {
            "insert_text": "right",
            "line_number": 5,
            "start": 9,
            "end": 20,
        },
        """Dear Manager,

I’m outraged!
My car warranty is
an total disaster.
Fix this right now!

Sincerely,""",
    ),
    (
        """Dear Manager,

I’m outraged!
My car warranty is
an total disaster.
Fix this right now!

Sincerely,""",
        EditType.NEWLINE,
        {
            "line_number": 7,
        },
        """Dear Manager,

I’m outraged!
My car warranty is
an total disaster.
Fix this right now!

Sincerely,
""",
    ),
    (
        """Dear Manager,

I’m outraged!
My car warranty is
an total disaster.
Fix this right now!

Sincerely,
""",
        EditType.INSERT,
        {
            "insert_text": "Karen",
            "line_number": 8,
            "start": 0,
        },
        """Dear Manager,

I’m outraged!
My car warranty is
an total disaster.
Fix this right now!

Sincerely,
Karen""",
    ),
    (
        """Dear Manager,

I’m outraged!
My car warranty is
an total disaster.
Fix this right now!

Sincerely,
Karen""",
        EditType.DELETE,
        {
            "line_number": 4,
            "start": 1,
            "end": 2,
        },
        """Dear Manager,

I’m outraged!
My car warranty is
a total disaster.
Fix this right now!

Sincerely,
Karen""",
    ),
]

submit_cases = run_cases + [
    (
        "test string",
        "Unknown edit type",
        {},
        "Unknown edit type",
    ),
    (
        "test string",
        EditType.NEWLINE,
        {
            "line_number": 1,
        },
        "Invalid line number",
    ),
    (
        "test string",
        EditType.SUBSTITUTE,
        {
            "insert_text": "case",
            "line_number": 1,
            "start": 0,
            "end": 0,
        },
        "Invalid line number",
    ),
    (
        "test string",
        EditType.INSERT,
        {
            "insert_text": "case",
            "line_number": 0,
            "start": 12,
        },
        "Invalid start index",
    ),
    (
        "test string",
        EditType.SUBSTITUTE,
        {
            "insert_text": "case",
            "line_number": 0,
            "start": 4,
            "end": 3,
        },
        "Invalid end index",
    ),
    (
        "test string",
        EditType.DELETE,
        {
            "line_number": 0,
            "start": 0,
            "end": 12,
        },
        "Invalid end index",
    ),
    (
        "test string",
        EditType.SUBSTITUTE,
        {
            "insert_text": "case",
            "line_number": 0,
            "start": 4,
            "end": 11,
        },
        "testcase",
    ),
]


def test(document, edit_type, edit, expected_output):
    print("---------------------------------")
    print(f"Change Type: {edit_type}")
    print("Inputs:")
    for key, val in edit.items():
        print(f"* {key}: {val}")
    print("Expected:")
    print(expected_output)
    try:
        result = handle_edit(document, edit_type, edit)
    # catch expected error or else raise unexpected error again
    except Exception as e:
        if type(e) is not Exception:
            raise
        result = str(e)
    print("Actual:")
    print(result)
    if result == expected_output:
        print("Pass")
        return True
    print("Fail")
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
