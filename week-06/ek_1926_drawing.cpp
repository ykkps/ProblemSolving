#include <iostream>
#include <queue>
#include <cmath>
#define MAX_NUM 502
using namespace std;

int n,m;
int dx[4] = {1,0,-1,0};
int dy[4] = {0,1,0,-1};
vector<vector<bool>> visited;
vector<vector<int>> arr;

bool IsValid(int x, int y) {
    if (x < 0 || x >= n || y < 0 || y >= m)
        return false;
    return true;
}

int BFS(int sx, int sy) {
    queue<pair<int, int>> q;
    // 현재 칸 처리
    q.push({sx, sy});
    visited[sx][sy] = true;
    int area = 1;

    while (!q.empty()) {
        int x = q.front().first;
        int y = q.front().second;
        q.pop();

        for (int k = 0; k < 4; k++) {
            int nx = x + dx[k];
            int ny = y + dy[k];
            
            if (IsValid(nx, ny) && arr[nx][ny] && !visited[nx][ny]) {
                q.push({nx,ny});
                visited[nx][ny] = true;
                area++;
            }
        }
    }
    
    return area;
}

int main(void) {
    ios_base::sync_with_stdio(false);
    cin.tie(nullptr);

    cin >> n >> m;
    
    arr.assign(n, vector<int>(m));
    visited.assign(n, vector<bool>(m, false));

    for (int row = 0; row < n; row++) {
        for (int col = 0; col < m; col++) 
            cin >> arr[row][col];
    }

    int count = 0;
    int maxArea = 0;
    
    for (int row = 0; row < n; row++) {
        for (int col = 0; col < m; col++) {
            if(arr[row][col] && !visited[row][col]) {
                maxArea = max(maxArea, BFS(row, col));
                count++;
            }
        }
    }

    cout << count << "\n" << maxArea;

    return 0;
}