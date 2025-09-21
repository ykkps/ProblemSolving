#include <bits/stdc++.h>
using namespace std;

int main()
{
    int i = 1;
    bool p = true;

    stack<int> s;
    string r = "";

    int n;
    cin >> n;

    while (n--)
    {
        int k;
        cin >> k;

        while (i <= k)
        {
            s.push(i++);
            r += '+';
        }

        if (s.top() == k)
        {
            s.pop();
            r += '-';
            continue;
        }
        else
        {
            p = false;
            break;
        }
    }

    if (!p)
        cout << "NO";
    else
    {
        for (char c : r)
            cout << c << '\n';
    }
}
