#include <bits/stdc++.h>
using namespace std;

int main()
{
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);

    int n, l;
    cin >> n >> l;

    deque<pair<int, int>> d;

    for (int i = 0; i < n; i++)
    {
        long int a;
        cin >> a;

        if (d.empty())
            d.push_back(make_pair(i, a));
        else
        {
            if (d.front().first <= (i - l))
                d.pop_front();

            while (!d.empty())
            {
                if (d.back().second > a)
                    d.pop_back();
                else
                    break;
            }

            d.push_back(make_pair(i, a));
        }
        cout << d.front().second << ' ';
    }
}