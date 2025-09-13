import sys
read = sys.stdin.readline

n = int(read().rstrip())
st = []
ans = 0

for _ in range(n):
    height = int(read().rstrip())

    # 0 : 높이, 1 : 같은 높이인 사람 수
    while st and st[-1][0] < height:
        ans += st[-1][1]
        st.pop()

    count = 1
    if st:
        if st[-1][0] == height:
            # 전부 같은 높이의 사람들만 있음
            if len(st) == 1:
                ans += st[-1][1]
            # 더 큰 사람이 있음
            else:
                ans += st[-1][1]+1
            # ans += (st[-1][1] if len(st) == 1 else (st[-1][1]+1) )

            count = st[-1][1] + 1
            st.pop()
        else:
            ans += count
    st.append([height, count])
    
print(ans)

# tc #1 : 9 2 4 3 2 2 2 1 2 5
# tc #2 : 5 1 1 1 1 