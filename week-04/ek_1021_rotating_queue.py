import sys
from collections import deque
read = sys.stdin.readline

n, m = map(int, read().split())
arr = list(map(int, read().split()))
dq = deque(range(1, n+1))

answer = 0
for target in arr:
    while True:
        # 1번 연산
        if dq[0] == target:
            dq.popleft()
            break
        else:
            # 2번 연산
            if dq.index(target) < (len(dq) / 2):
                while dq[0] != target:
                    dq.append(dq.popleft())
                    answer += 1
            # 3번 연산
            else:
                while dq[0] != target:
                    dq.appendleft(dq.pop())
                    answer += 1
print(answer)