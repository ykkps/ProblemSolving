import sys
from collections import deque
read = sys.stdin.readline

n = int(read().rstrip())
dq = deque(list(range(1, n+1)))

flag = True
while len(dq) > 1:
    if not flag:
        dq.append(dq[0])
    dq.popleft()
    flag = not flag

print(dq[0])