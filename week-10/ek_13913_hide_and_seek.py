import sys
from collections import deque
read = sys.stdin.readline

limit = 100001
n, k = map(int, read().split())
visited = [-1] * limit
path = [0] * limit

def find_way(end):
    ans = []    
    temp = end  
    for _ in range(visited[end]+1):
        ans.append(temp)
        temp = path[temp]
    print(' '.join(map(str, ans[::-1])))

def bfs(start, end):
    dq = deque()
    dq.append(start)

    visited[start] = 0
    path[start] = 0

    while dq:
        current = dq.popleft()

        if current == end:
            print(visited[current])
            find_way(current)
            return
    
        # move
        for next in (current-1, current+1, current * 2):
            if 0 <= next < limit and visited[next] == -1:
                dq.append(next)
                visited[next] = visited[current] + 1
                path[next] = current

bfs(n,k)