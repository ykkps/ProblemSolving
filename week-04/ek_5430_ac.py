import sys
from collections import deque
read = sys.stdin.readline

t = int(read().rstrip())

for _ in range(t):
    p = list(read().rstrip())
    n = int(read().rstrip())
    dq = deque(read().rstrip()[1:-1].split(','))
    
    if n == 0:
        dq = deque()

    is_front = True
    is_error = False
    for ch in p:
        if is_error:
            break

        if ch == 'R':
            is_front = not is_front
        elif ch == 'D':
            if len(dq) == 0:
                is_error = True
                break
            if is_front:
                dq.popleft()
            else:
                dq.pop()

    if is_error:
        print("error")
    else:
        if len(dq) == 0:
            print("[]")
        else:
            if not is_front:
                dq.reverse()
            print("[" + ",".join(dq) + "]")