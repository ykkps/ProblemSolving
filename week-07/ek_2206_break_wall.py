import sys
from collections import deque
read = sys.stdin.readline

dx = (1,0,-1,0)
dy = (0,1,0,-1)

def bfs():
    dq = deque()
    dq.append((0,0,0))
    visited[0][0][0] = 1

    while dq:
        z, x, y = dq.popleft()

        if x == n-1 and y == m-1:
            return visited[z][x][y]

        for k in range(4):
            nx = x + dx[k]
            ny = y + dy[k]

            if nx < 0 or nx >= n or ny < 0 or ny >= m:
                continue
            
            # 무난히 통과할 수 있음
            # 0이면 z가 0이든 1이든 통과 가능
            if arr[nx][ny] == '0' and visited[z][nx][ny] == 0:
                visited[z][nx][ny] = visited[z][x][y] + 1
                dq.append((z,nx,ny))
            if arr[nx][ny] == '1' and z == 0 and visited[1][nx][ny] == 0:
                visited[1][nx][ny] = visited[0][x][y] + 1
                dq.append((1,nx,ny))

    return -1

n,m = map(int, read().rstrip().split())
arr = [list(read().rstrip()) for _ in range(n)]
visited = [[[0 for _ in range(m)] for _ in range(n)] for _ in range(2)]

print(bfs())