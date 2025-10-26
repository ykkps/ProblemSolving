import sys
from collections import deque
read = sys.stdin.readline

dx = (1,0,-1,0)
dy = (0,1,0,-1)

def bfs():
    while dq:
        x, y = dq.popleft()

        for k in range(4):
            nx, ny = x + dx[k], y + dy[k]

            # 범위 안에 있음, 안 익은 토마토, 방문 안했음
            if 0 <= nx < n and 0 <= ny < m and tomato[nx][ny] == 0:
                dq.append((nx,ny))
                tomato[nx][ny] = tomato[x][y] + 1

def find_answer() -> int:
    ans = -1

    for row in range(n):
        for col in range(m):
            # 토마토 익었음
            if tomato[row][col] > 0:
                ans = max(ans, tomato[row][col])
            # 안 익은 토마토가 있음
            elif tomato[row][col] == 0:
                return -1
            
    return ans - 1

# 입력 받기
m, n = map(int, read().split())
tomato = [list(map(int, read().split())) for _ in range(n)]

dq = deque()

# 1. 익은 토마토 찾기
for row in range(n):
    for col in range(m):
        if tomato[row][col] == 1:
            dq.append((row, col))

# 2 토마토 익히기
bfs()
# 3 최소 날짜 찾기
print(find_answer())