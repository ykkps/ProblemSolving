#include <iostream>
#include <stack>
using namespace std;
int main() {
    ios_base::sync_with_stdio(false);
    cin.tie(nullptr);

    string ironStick;
    cin >> ironStick;

    int answer = 0;
    stack<char> st; 
    for(int idx = 0; idx < ironStick.length(); idx++) {
        if (ironStick[idx] == '(')
            st.push(ironStick[idx]);
        else {
            st.pop();
            if (ironStick[idx-1] == '(')
                answer += st.size();
            else
                answer += 1;
        }
    }

    cout << answer;
    return 0;
}