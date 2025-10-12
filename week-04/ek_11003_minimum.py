import sys
from collections import deque
read = sys.stdin.readline

n, l = map(int, read().rstrip().split())
arr = list(map(int, read().rstrip().split()))

dq = deque()
answer = []
for index, number in enumerate(arr, start=1):
    # 구간 벗어남
    min_index = index - l + 1
    while dq and dq[0][0] < min_index:
        dq.popleft()

    # 최솟값을 찾는거니까 큰 수는 빼기
    while dq and dq[-1][1] >= number:
        dq.pop()

    dq.append((index, number))
    answer.append(dq[0][1])

print(*answer)