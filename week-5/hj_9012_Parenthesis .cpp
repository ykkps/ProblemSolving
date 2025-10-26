#include <bits/stdc++.h>
using namespace std;

int main()
{
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);

    int n;
    cin >> n;

    while (n--)
    {
        string s;
        cin >> s;
        
        stack<char> t;
        bool b = true;
        
        for (char c : s)
        {
        	if (c == '(')
        		t.push(c);
        	else 
        	{
        		if (t.empty())
        		{
        			b = false;
        			break;
        		}
        		t.pop();
        	}
        }
        if (!t.empty())
        	b = false;
        
        cout << (b ? "YES\n" : "NO\n");
    }
}