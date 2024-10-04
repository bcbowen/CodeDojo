from pathlib import Path
from contextlib import redirect_stdout

print('starting')
path = Path(Path(__file__).parent, "file.txt").resolve()
print(path)
with open(path, 'w') as f:
    with redirect_stdout(f):
        print('fuckballs!')
        
print('done')

def do_shit(log: list[str]): 
    log.append("Doing shit")

log = [] 
for i in range(0, 10): 
    do_shit(log)

for line in log: 
    print(line)