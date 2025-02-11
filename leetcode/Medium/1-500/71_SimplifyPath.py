import pytest

class Solution:
    def simplifyPath(self, path: str) -> str:
        parts = path.split('/')
        fields = []
        for part in parts: 
            match part: 
                case "..": 
                    if fields: 
                        fields.pop()
                case ".": 
                    pass #noop
                case _: 
                    part = part.strip('/')
                    if part: 
                        fields.append(part)
        return "/" + "/".join(fields)


"""
Example 1:
Input: path = "/home/"
Output: "/home"
Explanation:
The trailing slash should be removed.

Example 2:
Input: path = "/home//foo/"
Output: "/home/foo"
Explanation:
Multiple consecutive slashes are replaced by a single one.

Example 3:
Input: path = "/home/user/Documents/../Pictures"
Output: "/home/user/Pictures"
Explanation:
A double period ".." refers to the directory up a level (the parent directory).

Example 4:
Input: path = "/../"
Output: "/"
Explanation:
Going one level up from the root directory is not possible.

Example 5:
Input: path = "/.../a/../b/c/../d/./"
Output: "/.../b/d"
Explanation:
"..." is a valid name for a directory in this problem.
"""
@pytest.mark.parametrize("path, expected", [
    ("/home/", "/home"),
    ("/home//foo/", "/home/foo"),
    ("/home/user/Documents/../Pictures", "/home/user/Pictures"),
    ("/../", "/"),
    ("/.../a/../b/c/../d/./", "/.../b/d") 
])
def test_simplifyPath(path: str, expected: str):
    sol = Solution()
    result = sol.simplifyPath(path)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])