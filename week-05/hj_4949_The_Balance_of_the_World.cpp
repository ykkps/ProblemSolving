#include <bits/stdc++.h>
using namespace std;

int main()
{
	while (true)
	{
		string s;
		getline(cin, s);

		if (s == ".")
			break;

		stack<char> t;
		bool b = true;

		for (char c : s)
		{
			if (c == '(' || c == '[')
				t.push(c);

			else if (c == ')' || c == ']')
			{
				if (t.empty())
				{
					b = false;
					break;
				}

				if (c == ')')
				{
					if (t.top() == '(')
						t.pop();
					else
					{
						b = false;
						break;
					}
				}
				else
				{
					if (t.top() == '[')
						t.pop();
					else
					{
						b = false;
						break;
					}
				}
			}
		}
		if (!t.empty())
			b = false;

		cout << (b ? "yes\n" : "no\n");
	}
}