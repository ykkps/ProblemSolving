#include <bits/stdc++.h>
using namespace std;

deque<int> split(string input, char deli)
{
    deque<int> dq;
    stringstream ss(input);
    string t;

    while (getline(ss, t, deli))
        dq.push_back(stoi(t));

    return dq;
}

int main()
{
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);

    int t;
    cin >> t;

    while (t--)
    {
        string s;
        cin >> s;

        int n;
        cin >> n;

        string x;
        cin >> x;

        x = x.substr(1, x.length() - 2);

        deque<int> d = split(x, ',');

        bool l = true;
        bool r = true;

        for (char c : s)
        {
            if (c == 'R')
            {
                l = !l;
                continue;
            }

            if (d.empty())
            {
                r = false;
                break;
            }

            if (l)   // 정방향
                d.pop_front();
            else     // 역방향
                d.pop_back();
        }

        if (r)
        {
            cout << '[';

            if (l && !d.empty())
            {
                while (d.size() > 1)
                {
                    cout << d.front() << ',';
                    d.pop_front();
                }
                cout << d.front();
            }
            else if (!l && !d.empty())
            {
                while (d.size() > 1)
                {
                    cout << d.back() << ',';
                    d.pop_back();
                }
                cout << d.back();
            }
            cout << ']' << '\n';
        }
        else
            cout << "error" << '\n';
    }
}