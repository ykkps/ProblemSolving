#include <iostream>
#include <algorithm>
#include <deque>
using namespace std;

int main(void) {
    ios_base::sync_with_stdio(false);
    cin.tie(nullptr);

    int n, l, temp;
    cin >> n >> l;

    deque<pair<int, int>> dq;

    for (int index = 1; index <= n; index++) {
        cin >> temp;

        int minIndex = index - l + 1;
        while (!dq.empty() && dq.front().first < minIndex)
            dq.pop_front();

        while (!dq.empty() && dq.back().second >= temp)
            dq.pop_back();

        dq.push_back({index, temp});
        cout << dq.front().second << " ";
    }

    return 0;
}