#include <bits/stdc++.h>

int main() {
    std::ios::sync_with_stdio(false);
    std::cin.tie(nullptr);

    int n, m;
    std::cin >> n >> m;

    std::deque<int> dq;
    for (int i = 1; i <= n; i++) {
        dq.push_back(i);
    }

    int result = 0;

    while(m > 0) {
        int target;
        std::cin >> target;

        int index = 0;
        for (int i = 0; i < dq.size(); i++) {
            if (dq[i] == target) {
                index = i;
                break;
            }
        }

        int leftDistance = index;
        int rightDistance = dq.size() - index;

        if (leftDistance > rightDistance) { // Right shift
            while (rightDistance > 0) {
                dq.push_front(dq.back());
                dq.pop_back();
                result++;
                rightDistance--;
            }
        }
        else {
            while(leftDistance > 0) {
                dq.push_back(dq.front());
                dq.pop_front();
                result++;
                leftDistance--;
            }
        }
        dq.pop_front();
        m--;
    }
    std::cout << result;

}