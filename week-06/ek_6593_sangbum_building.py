import sys
from collections import deque
read = sys.stdin.readline

dir = [(1,0,0),(0,1,0),(-1,0,0),(0,-1,0),(0,0,1),(0,0,-1)]

def bfs(building, dq, l, r, c) -> int:
    visited = [[[0] * c for _ in range(r)] for __ in range(l)]

    while dq:
        h, x, y = dq.popleft()

        for dh, dx, dy in dir:
            nh = h + dh
            nx = x + dx
            ny = y + dy

            if (0 <= nh < l and 0 <= nx < r and 0 <= ny < c):
                if building[nh][nx][ny] == 'E':
                    return visited[h][x][y] + 1
                    
                if visited[nh][nx][ny] == 0 and building[nh][nx][ny] == '.':
                    visited[nh][nx][ny] = visited[h][x][y] + 1
                    dq.append((nh,nx,ny))

    return -1

while True:
    l, r, c = map(int, read().split())
    if l == 0 and r == 0 and c == 0:
        break

    building = []
    for _ in range(l):
        floor = [list(read().rstrip()) for _ in range(r)]
        read().rstrip()
        building.append(floor)


    # building = [[list(read().rstrip()) for _ in range(r)] for __ in range(l)]
    dq = deque()

    for height in range(l):
        for row in range(r):
            for col in range(c):
                if building[height][row][col] == 'S':
                    dq.append((height, row, col))
    
    ans = bfs(building, dq, l, r, c)
    if ans == -1:
        print("Trapped!")
    else:
        print(f"Escaped in {ans} minute(s).")
    
    