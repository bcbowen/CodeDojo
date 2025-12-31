import pytest

from typing import List

class Solution:
    @staticmethod
    def filter_email(email: str) -> str: 
        name, domain = email.split('@')

        if '+' in name: 
            pos = name.index('+')
            name = name[:pos]

        name = name.replace('.', '')
        return f"{name}@{domain}"

    def numUniqueEmails(self, emails: List[str]) -> int:
        uniques = set()
        for email in emails: 
            filtered = Solution.filter_email(email)
            uniques.add(filtered)
        return len(uniques)
    


"""
Example 1:
Input: emails = ["test.email+alex@leetcode.com","test.e.mail+bob.cathy@leetcode.com","testemail+david@lee.tcode.com"]
Output: 2
Explanation: "testemail@leetcode.com" and "testemail@lee.tcode.com" actually receive mails.

Example 2:
Input: emails = ["a@leetcode.com","b@leetcode.com","c@leetcode.com"]
Output: 3
"""
@pytest.mark.parametrize("emails, expected", [
    (["test.email+alex@leetcode.com","test.e.mail+bob.cathy@leetcode.com","testemail+david@lee.tcode.com"], 2),
    (["a@leetcode.com","b@leetcode.com","c@leetcode.com"], 3) 
])
def test_numUniqueEmails(emails: List[str], expected: int):
    result = Solution().numUniqueEmails(emails)
    assert(result == expected)

    


    

"""
For example, "alice.z@leetcode.com" and "alicez@leetcode.com" forward to the same email address.
If you add a plus '+' in the local name, everything after the first plus sign will be ignored. This allows certain emails to be filtered. Note that this rule does not apply to domain names.

For example, "m.y+name@email.com" will be forwarded to "my@email.com".
"""
@pytest.mark.parametrize("email, expected", [
    ("alice.z@leetcode.com", "alicez@leetcode.com"),
    ("m.y+name@email.com", "my@email.com"),
    ("ben.bowen@aol.com", "benbowen@aol.com"),
    ("ben+yada@aol.com", "ben@aol.com"), 
    ("ben+yada+yada+yada@aol.com", "ben@aol.com")
])
def test_filter_email(email: str, expected: str): 
    result = Solution.filter_email(email)
    assert(result == expected)

def test_case_3(): 
    emails = ["fg.r.u.uzj+o.pw@kziczvh.com","r.cyo.g+d.h+b.ja@tgsg.z.com","fg.r.u.uzj+o.f.d@kziczvh.com","r.cyo.g+ng.r.iq@tgsg.z.com","fg.r.u.uzj+lp.k@kziczvh.com","r.cyo.g+n.h.e+n.g@tgsg.z.com","fg.r.u.uzj+k+p.j@kziczvh.com","fg.r.u.uzj+w.y+b@kziczvh.com","r.cyo.g+x+d.c+f.t@tgsg.z.com","r.cyo.g+x+t.y.l.i@tgsg.z.com","r.cyo.g+brxxi@tgsg.z.com","r.cyo.g+z+dr.k.u@tgsg.z.com","r.cyo.g+d+l.c.n+g@tgsg.z.com","fg.r.u.uzj+vq.o@kziczvh.com","fg.r.u.uzj+uzq@kziczvh.com","fg.r.u.uzj+mvz@kziczvh.com","fg.r.u.uzj+taj@kziczvh.com","fg.r.u.uzj+fek@kziczvh.com"]
    result = Solution().numUniqueEmails(emails)
    expected = 2
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 