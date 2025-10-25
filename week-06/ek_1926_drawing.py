import sys
from collections import deque
read = sys.stdin.readline

dx = (1,0,-1,0)
dy = (0,1,0,-1)

def is_valid(x: int, y: int) -> bool:
    return False if x < 0 or x >= n or y < 0 or y >= m else True

def bfs(x: int, y: int) -> int:
    dq = deque([(x,y)])
    visited[x][y] = True # 현재 칸 방문 표시
    area = 1   # 현재 칸 포함
    
    while dq:
        sx, sy = dq.popleft()

        for k in range(4):
            nx, ny = sx + dx[k], sy + dy[k]

            if not is_valid(nx,ny) or visited[nx][ny] or not arr[nx][ny]:
                continue

            area += 1
            visited[nx][ny] = True
            dq.append((nx,ny))

    return area


n, m = map(int, read().split())
arr = [list(map(int, read().split())) for _ in range(n)]
visited = [ [False] * m for r_ in range(n)]

count = 0
max_area = 0

for row in range(n):
    for col in range(m):
        if not visited[row][col] and arr[row][col]:
            max_area = max(max_area, bfs(row, col))
            count += 1

print(count)
print(max_area)