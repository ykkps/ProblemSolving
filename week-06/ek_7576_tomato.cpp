#include <iostream>
#include <queue>
#include <vector>
#include <cmath>
using namespace std;

int dx[4] = {1,0,-1,0};
int dy[4] = {0,1,0,-1};
int n,m;
vector<vector<int>> tomato;

int FindAnswer() {
    int ans = -1;
    for(int row = 0; row < n; row++) {
        for (int col = 0; col < m; col++) {
            if(tomato[row][col] == 0) {
                return -1;
            }
            else if(tomato[row][col] > 0) {
                ans = max(ans, tomato[row][col]);
            }
        }
    }
    return ans-1;
}

int main(void) {
    ios_base::sync_with_stdio(false);
    cin.tie(nullptr);

    cin >> m >> n;
    tomato.assign(n, vector<int> (m));

    queue<pair<int,int>> q;
    for (int row = 0; row < n; row++) {
        for (int col = 0; col < m; col++) {
            cin >> tomato[row][col];

            if(tomato[row][col] == 1)
                q.push({row, col});
        }
    }

    while (!q.empty()) {
        int x = q.front().first;
        int y = q.front().second;
        q.pop();

        for(int k = 0; k < 4; k++) {
            int nx = x + dx[k];
            int ny = y + dy[k];

            if (0 <= nx && nx < n && 0 <= ny && ny < m && tomato[nx][ny] == 0) {
                tomato[nx][ny] = tomato[x][y] + 1;
                q.push({nx,ny});
            }
        }
    }

    cout << FindAnswer();
    
    return 0;
}