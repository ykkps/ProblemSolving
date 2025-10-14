#include <iostream>
#include <string>
#include <stack>
using namespace std;

int main(void) {
    ios_base::sync_with_stdio(false);
    cin.tie(nullptr);

    int n;
    cin >> n;

    int answer = 0;
    string word;
    while(n--) {
        cin >> word;

        stack<int> st;
        for(auto ch : word) {
            if (!st.empty() && st.top() == ch)
                st.pop();
            else
                st.push(ch);
        }

        answer += (st.empty() ? 1 : 0);
    }

    cout << answer;
    
    return 0;
}