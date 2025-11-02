import sys
from collections import deque
read = sys.stdin.readline

dx = (1,0,-1,0)
dy = (0,1,0,-1)

def can_escape(x: int, y: int) -> bool:
    # 가장자리 도착했는데 빈공간이거나 시작위치 -> 탈출 가능
    if (x == 0 or x == h-1 or y == 0 or y == w-1) and (building[x][y] == '.' or building[x][y] == '@'):
        return True
    return False

def can_spread(x: int, y: int) -> bool:
    # 빌딩 범위 안에 있고 빈공간이거나 시작위치 -> 이동 가능
    if 0 <= x < h and 0 <= y < w and (building[x][y] == '.' or building[x][y] == '@'):
        return True
    return False

def bfs(building, sg, fire, w, h):
    while sg or fire:
        # 상근이는 불이 붙으려는 칸으로 이동할 수 없기 떄문에 불을 먼저 옮긴다
        for _ in range(len(fire)):
            x, y = fire.popleft()

            for k in range(4):
                nx, ny = x + dx[k], y + dy[k]
                
                # 빈 공간이거나 상근이 시작 위치 -> 불 옮길 수 있음
                if can_spread(nx, ny) and visited[nx][ny] == 0:  
                    building[nx][ny] = '*'
                    visited[nx][ny] = visited[x][y] + 1
                    fire.append((nx,ny))

        # 상근이 도망
        for _ in range(len(sg)):
            x, y = sg.popleft()

            if can_escape(x,y):
                return visited[x][y]

            for k in range(4):
                nx, ny = x + dx[k], y + dy[k]

                if can_spread(nx, ny) and visited[nx][ny] == 0:
                    visited[nx][ny] = visited[x][y] + 1
                    sg.append((nx,ny))

    return "IMPOSSIBLE"

# tc
t = int(read().rstrip())

for _ in range(t):
    w, h = map(int, read().split())
    building = [list(read().rstrip()) for _ in range(h)]
    visited = [[0] * w for _ in range(h)]

    sg = deque()
    fire = deque()

    for row in range(h):
        for col, temp in enumerate(building[row]):
            if temp == '@':
                sg.append((row, col))
                visited[row][col] = 1
            elif temp == '*':
                fire.append((row, col))

    print(bfs())