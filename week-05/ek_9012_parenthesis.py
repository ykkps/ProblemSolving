import sys
read = sys.stdin.readline

t = int(read().rstrip())

for _ in range(t):
    temp = list(read().rstrip())
    st = []

    for ch in temp:
        # 여는 괄호
        if ch == '(':
            st.append(ch)
        # 닫는 괄호인데 스택이 비었음 
        elif not st:
            st.append(ch)
            break
        else:
            st.pop()

    print("YES" if not st else "NO")
