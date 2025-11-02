import sys
from collections import deque
read = sys.stdin.readline

dx = (1,0,-1,0)
dy = (0,1,0,-1)

n = int(read().rstrip())
arr = [list(map(int, read().split())) for _ in range(n)]

max_height = 1
safe_area = 1 # 노트에 따라 모든 영역이 잠기지 않았을수 있으므로 최소는 1

for row in range(n):
    for col in range(n):
        max_height = max(max_height, arr[row][col])

for rain in range(1, max_height):
    visited = [[False] * n for _ in range(n)]
    count = 0

    for row in range(n):
        for col in range(n):
            # 비가 안 잠기는 영역 발견
            if arr[row][col] > rain and not visited[row][col]:
                dq = deque([(row,col)])
                visited[row][col] = True
                count += 1

                while dq:
                    x, y = dq.popleft()

                    for k in range(4):
                        nx, ny = x + dx[k], y + dy[k]

                        if (0 <= nx < n and 0 <= ny < n) and arr[nx][ny] > rain and not visited[nx][ny]:
                            visited[nx][ny] = True
                            dq.append((nx,ny))
    
    safe_area = max(safe_area, count)
print(safe_area)