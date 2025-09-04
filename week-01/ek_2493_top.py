import sys
read = sys.stdin.readline

n = int(read().rstrip())
arr = list(map(int, read().rstrip().split()))
st = []
ans = []

for idx, temp in enumerate(arr, start=1):
    # 현재 탑의 높이보다 작은 탑들은 레이저 수신을 못하니까 pop
    while st and st[-1][1] < temp:
        st.pop()

    # 스택에 남아있는 탑은 현재 탑의 레이저를 수신할 수 있음
    # 스택이 비어있으면 레이저 수신 못함
    ans.append(st[-1][0] if st else 0)
    st.append([idx, temp])

print(*ans)