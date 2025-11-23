import sys
from collections import deque
read = sys.stdin.readline

dist = ((1,0),(0,1),(-1,0),(0,-1))
horse = ((-2,-1), (-2,1),(-1,-2),(-1,2),(2,-1),(2,1),(1,-2),(1,2))

def bfs(count, width, height):
    visited = [[[0] * width for _ in range(height)] for _ in range(count + 1)]
    dq = deque()
    dq.append((0,0,0))
    visited[0][0][0] = 1
    
    while dq:
        z, x, y = dq.popleft()
        
        if x == height-1 and y == width-1:
            return visited[z][x][y]-1
        
        for dx, dy in dist:
            nx, ny = x + dx, y + dy
            if 0 <= nx < height and 0 <= ny < width and not arr[nx][ny] and not visited[z][nx][ny]:
                visited[z][nx][ny] = visited[z][x][y]+1
                dq.append((z,nx,ny))
            
        if z < count:
            for dx, dy in horse:
                nx, ny = x + dx, y + dy
                if 0 <= nx < height and 0 <= ny < width and not arr[nx][ny] and not visited[z+1][nx][ny]:
                    visited[z+1][nx][ny] = visited[z][x][y]+1
                    dq.append((z+1,nx,ny))

    return -1

k = int(read())
w, h = map(int, read().split())
arr = [list(map(int, read().split())) for _ in range(h)]

print(bfs(k, w, h))