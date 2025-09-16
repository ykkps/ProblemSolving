import sys
from collections import deque
read = sys.stdin.readline

n = int(read().rstrip())
dq = deque()

for _ in range(n):
    ord = list(read().split())

    if ord[0] == "push":
        dq.append(int(ord[1]))
    elif ord[0] == "pop":
        print(dq.popleft() if dq else -1)
    elif ord[0] == "size":
        print(len(dq))
    elif ord[0] == "empty":
        print(0 if dq else 1)
    elif ord[0] == "front":
        print(dq[0] if dq else -1)
    elif ord[0] == "back":
        print(dq[-1] if dq else -1)
