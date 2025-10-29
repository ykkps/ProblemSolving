import sys
read = sys.stdin.readline

iron_stick = read().rstrip()

st = []
answer = 0
for idx, ch in enumerate(iron_stick):
    if ch == '(':
        st.append(ch)
    else:
        st.pop()
        # 직전이 닫는 괄호면 레이저 아니면 막대기
        answer += (len(st) if iron_stick[idx-1] == '(' else 1)
print(answer)