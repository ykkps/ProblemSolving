import sys
from collections import deque
read = sys.stdin.readline

MAX = 100001
n, k = map(int, read().split())
visited = [-1] * MAX

def bfs(start, end):
    dq = deque()
    dq.append(start)
    visited[start] = 0

    while dq:
        current = dq.popleft()

        if current == end:
            return visited[current]
        
        jump = 2*current
        front = current-1
        back = current+1

        if 0 <= jump < MAX and visited[jump] == -1:
            dq.append(jump)
            visited[jump] = visited[current]
        if 0 <= front < MAX and visited[front] == -1:
            dq.append(front)
            visited[front] = visited[current] + 1
        if 0 <= back < MAX and visited[back] == -1:
            dq.append(back)
            visited[back] = visited[current] + 1

print(bfs(n,k))