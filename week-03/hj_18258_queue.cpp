#include <bits/stdc++.h>
using namespace std;

int main()
{
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);

    int n;
    cin >> n;

    queue<int> q;

    while (n--)
    {
        string s;
        cin >> s;

        if (s == "push")
        {
            int x;
            cin >> x;
            q.push(x);
        }
        else if (s == "pop")
        {
            if (!q.empty())
            {
                cout << q.front() << '\n';
                q.pop();
            }
            else
                cout << -1 << '\n';
        }
        else if (s == "size")
            cout << q.size() << '\n';
        else if (s == "empty")
            cout << (q.empty() ? 1 : 0) << '\n';
        else if (s == "front")
            cout << (q.empty() ? -1 : q.front()) << '\n';
        else
            cout << (q.empty() ? -1 : q.back()) << '\n';
    }
}