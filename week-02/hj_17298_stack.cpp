#include <bits/stdc++.h>
using namespace std;

int a[1000001];
int main()
{
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);

    fill(a, a + 1000001, -1);

    stack<pair<int, int>> s;

    int n;
    cin >> n;

    for (int i = 0; i < n; i++)
    {
        int h;
        cin >> h;

        while (!s.empty())
        {
            if (s.top().second < h)
            {
                a[s.top().first] = h;
                s.pop();
            }
            else
                break;
        }
        s.push(pair<int, int>(i, h));
    }

    for (int i = 0; i < n; i++)
    {
        cout << a[i] << ' ';
    }
}