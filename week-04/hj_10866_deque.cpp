#include <bits/stdc++.h>
using namespace std;

int main()
{
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);

    int n;
    cin >> n;

    deque<int> d;

    while (n--)
    {
        string s;
        cin >> s;

        int x;
        if (s == "push_front")
        {
            cin >> x;
            d.push_front(x);
        }
        else if (s == "push_back")
        {
            cin >> x;
            d.push_back(x);
        }
        else if (s == "pop_front")
        {
            if (!d.empty())
            {
                cout << d.front() << '\n';
                d.pop_front();
            }
            else
                cout << -1 << '\n';
        }
        else if (s == "pop_back")
        {
            if (!d.empty())
            {
                cout << d.back() << '\n';
                d.pop_back();
            }
            else
                cout << -1 << '\n';
        }
        else if (s == "size")
            cout << d.size() << '\n';
        else if (s == "empty")
            cout << (d.empty() ? 1 : 0) << '\n';
        else if (s == "front")
            cout << (d.empty() ? -1 : d.front()) << '\n';
        else
            cout << (d.empty() ? -1 : d.back()) << '\n';
    }
}