git filter-repo --commit-callback '
if commit.author_email == b"bbowen@bhg-inc.com":
    commit.author_email = b"bcbowen@gmail.com"
    commit.author_name = b"Ben Bowen"
if commit.committer_email == b"bbowen@bhg-inc.com":
    commit.committer_email = b"bcbowen@gmail.com"
    commit.committer_name = b"Ben Bowen"
' --force

