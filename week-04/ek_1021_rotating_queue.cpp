#include <iostream>
#include <algorithm>
#include <deque>

using namespace std;

int main() {
    ios_base::sync_with_stdio(false);
    cin.tie(nullptr);

    int n,m;
    cin >> n >> m;

    int temp;
    vector<int> arr;
    for (int i = 0; i < m; i++) {
        cin >> temp;
        arr.push_back(temp);
    }

    deque<int> dq;
    for (int i = 1; i <= n; i++)
        dq.push_back(i);

    int answer = 0;
    for (auto target : arr) {
        while (true) {
            // 1번 연산
            if (dq.front() == target) {
                dq.pop_front();
                break;
            }
            
            int idx = find(dq.begin(), dq.end(), target) - dq.begin();
            if(idx <= (dq.size()/2)) {
                // 2번 연산
                while (dq.front() != target) {
                    dq.push_back(dq.front());
                    dq.pop_front();
                    answer += 1;
                }
            }
            else {
                // 3번 연산
                while (dq.front() != target) {
                    dq.push_front(dq.back());
                    dq.pop_back();
                    answer += 1;
                }
            }
        }
    }

    cout << answer;
    
    return 0;
}