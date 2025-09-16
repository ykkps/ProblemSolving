#include <iostream>
#include <queue>

using namespace std;

int main(void) {
    ios_base::sync_with_stdio(false);
    cin.tie(nullptr);

    int n;
    cin >> n;

    queue<int> q;
    string order;

    while(n--) {
        cin >> order;

        if(order == "push") {
            int temp;
            cin >> temp;
            q.push(temp);
        } else if (order == "pop") {
            if(q.empty())
                cout << -1 << "\n";
            else {
                cout << q.front() << "\n";
                q.pop();
            }
        } else if (order == "size") {
            cout << q.size() << "\n";
        } else if (order == "empty") {
            cout << (q.empty() ? 1 : 0) << "\n";
        } else if (order == "front") {
            cout << (q.empty() ? -1 : q.front()) << "\n";
        } else if (order == "back") {
            cout << (q.empty() ? -1 : q.back()) << "\n";
        }
   }

    return 0;
}