#include <iostream>
#include <queue>

using namespace std;

int main(void) {
    ios_base::sync_with_stdio(false);
    cin.tie(nullptr);

    int n;
    cin >> n;

    queue<int> q;
    for (int i = 1; i <= n; i++)
        q.push(i);

    bool shouldDrop = true;
    while (q.size() > 1) {
        if (!shouldDrop) 
            q.push(q.front());
        q.pop();
        shouldDrop = !shouldDrop;
    }

    cout << q.front();
    
    return 0;
}