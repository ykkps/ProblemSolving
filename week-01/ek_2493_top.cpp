#include <iostream>
#include <string>
#include <stack>

using namespace std;

int main(void) {
    ios_base::sync_with_stdio(false);
    cin.tie(nullptr);

    int n, temp;
    cin >> n;

    // 탑 순서, 높이
    stack<pair<int,int>> st;

    for(int i = 1; i <= n; i++) {
        cin >> temp;

        while (!st.empty() && st.top().second < temp)
            st.pop();

        if (st.empty())
            cout << "0 ";
        else
            cout << st.top().first << " ";
        st.push({i, temp});        
    }
    
    return 0;
}