#include <bits/stdc++.h>
using namespace std;

int main()
{
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);

    int n;
    cin >> n;
    stack<int> s;

    long long int r = 0;
    while(n--)
    {
        int h;
        cin >> h;

        while (!s.empty())
        {
            if (s.top() <= h)
            {
                r += s.size() - 1;
                s.pop();
            }
            else
                break;    
        }
        s.push(h);
    }
    
    while (!s.empty())
    {
        r += s.size() - 1;
        s.pop();
    }

    cout << r;
}