#include <iostream>
#include <stack>
using namespace std;
int main() {
    ios_base::sync_with_stdio(false);
    cin.tie(nullptr);

    int t;
    cin >> t;

    while(t--) {
        string str;
        cin >> str;

        stack<char> st;
        for (auto ch : str) {
            if (ch == '(')
                st.push(ch);
            else if (st.empty()) {
                st.push(ch);
                    break;
            }
            else
                st.pop();
        }

        if (st.empty())
            cout << "YES\n";
        else
            cout << "NO\n";
    }
    return 0;
}