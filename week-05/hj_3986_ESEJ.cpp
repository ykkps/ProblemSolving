#include <bits/stdc++.h>
using namespace std;

int main()
{
	int c = 0;

	int n;
	cin >> n;

	while (n--)
	{
		string s;
		cin >> s;

		stack<char> t;

		for (char c : s)
		{
			if (t.empty())
				t.push(c);
			else
			{
				if (t.top() == c)
					t.pop();
				else
					t.push(c);
			}
		}
		if (t.empty())
			c++;
	}
	cout << c;
}