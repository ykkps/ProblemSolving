#include <iostream>
#include <stack>
using namespace std;

int main(void)
{
	ios_base::sync_with_stdio(false);
	cin.tie(nullptr);

	int n, temp;
	cin >> n;

	stack<int> st;
	long long ans = 0;

	while (n--)
	{
		cin >> temp;

		while (!st.empty() && st.top() <= temp)
			st.pop();

		ans += st.size();
		st.push(temp);
	}

	cout << ans;

	return 0;
}