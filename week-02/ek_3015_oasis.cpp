#include <iostream>
#include <stack>

using namespace std;

int main(void) {
    ios_base::sync_with_stdio(false);
    cin.tie(nullptr);

    int n, height, count;
    cin >> n;

    long ans = 0;
    stack<pair<int,int>> st;
    while (n--) {
        cin >> height;

        count = 1;
        while (!st.empty() && st.top().first <= height) {
            ans += st.top().second;

            if(st.top().first == height)
                count = st.top().second + 1;
            st.pop();
        }

        // 앞에 큰 사람이 있음
        if (!st.empty())
            ans++;

        st.push({height, count});
    }

    cout << ans;

    return 0;
}