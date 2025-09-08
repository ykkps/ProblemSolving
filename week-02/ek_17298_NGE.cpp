#include <iostream>
#include <stack>
using namespace std;

int ans[1000002];
int main(void) {
    ios::sync_with_stdio(false);
    cin.tie(nullptr);

    int n, number;
    cin >> n;

    stack<pair<int,int>> st;

    for(int idx = 0; idx < n; idx++) {
        cin >> number;

        while (!st.empty() && st.top().second < number) {
            ans[st.top().first] = number;
            st.pop();
        }

        st.push({idx, number});
    }

    for(int i = 0; i< n; i++) 
        cout << (ans[i] == 0 ? -1 : ans[i]) << " ";
    return 0;
}