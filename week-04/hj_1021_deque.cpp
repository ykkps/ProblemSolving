#include <bits/stdc++.h>
using namespace std;

int main()
{
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);

    int n, m;
    cin >> n >> m;

    deque<int> d;

    for (int i = 1; i <= n; i++)
        d.push_back(i);

    int c = 0;

    while (m--)
    {
        int x;
        cin >> x;

        int idx = 0;
        for (int i : d)
            if (i == x)
                break;
            else
                idx++;

        if (idx <= (d.size() / 2))
        {
            while (d.front() != x)
            {
                d.push_back(d.front());
                d.pop_front();
                c++;
            }
        }
        else
        {
            while (d.front() != x)
            {
                d.push_front(d.back());
                d.pop_back();
                c++;
            }
        }
        d.pop_front();
    }
    cout << c;
}