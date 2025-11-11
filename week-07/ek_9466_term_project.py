import sys
sys.setrecursionlimit(100000)
read = sys.stdin.readline

def dfs(node: int):
    global count
    visited[node] = True
    next = students[node]

    if not visited[next]:
        dfs(next)
    else:
        if not finished[next]:
            temp = next
            while temp != node:
                count += 1
                temp = students[temp]
            count += 1
    finished[node] = True

t = int(read().rstrip())

for _ in range(t):
    n = int(read().rstrip())
    students = [0] + list(map(int, read().split()))
    visited = [False] * (n + 1)
    finished = [False] * (n + 1)
    count = 0

    for idx in range(n):
        if not visited[idx+1]:
            dfs(idx+1)

    print(n - count)
