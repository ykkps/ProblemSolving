#include <bits/stdc++.h>
using namespace std;

int main()
{
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);

    int n;
    cin >> n;

    stack<pair<long,long>> s;
    long long r = 0;

    while (n--)
    {
        unsigned int h;
        cin >> h;

        long d = 0;
        while (!s.empty())
        {
            if (s.top().first < h)
            {
                r += s.top().second + 1;
                s.pop();
            }
            else if (s.top().first == h)
            {
                r += s.top().second + 1;
                d = s.top().second + 1;
                s.pop();
            }
            else
            {
                break;
            }
        }
        if (!s.empty())
            r++;
        s.push(make_pair(h, d));
    }
    cout << r;
}
