import sys
read = sys.stdin.readline

n = int(read().rstrip())
suyeol = list(map(int, read().split()))
ans = [-1] * n

st = []
for idx, number in enumerate(suyeol):
    while st and suyeol[st[-1]] < number:
        ans[st[-1]] = number
        st.pop()

    st.append(idx)

print(*ans)