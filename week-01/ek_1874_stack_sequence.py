from sys import stdin
read = stdin.readline

# input
n = int(read().rstrip())
arr = [int(read().rstrip()) for _ in range(n)]
st = []

cur = 1
ans = []
flag = False

for temp in arr:
    # impossible
    if flag:
        break

    for num in range(cur, temp+1):
        st.append(num)
        ans.append("+")
        cur = temp+1
    
    # 입력한 숫자가 아니므로 수열 만들 수 없음
    if st and st[-1] != temp:
        flag = True
    
    st.pop()
    ans.append("-")

if flag:
    print("NO")
else:
    print(*ans, sep="\n")