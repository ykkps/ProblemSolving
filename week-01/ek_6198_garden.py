import sys
read = sys.stdin.readline

n = int(read().rstrip())

st = []
ans = 0
for _ in range(n):
    temp = int(read().rstrip())

    while st and st[-1] <= temp:
        st.pop()

    ans += len(st)
    st.append(temp)

print(ans)