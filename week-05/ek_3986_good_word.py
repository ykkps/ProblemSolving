import sys
read = sys.stdin.readline

n = int(read().rstrip())
answer = 0

for _ in range(n):
    st = []

    for ch in read().rstrip():
        if st and st[-1] == ch:
            st.pop()
        else:
            st.append(ch)
    
    answer += not st

print(answer)