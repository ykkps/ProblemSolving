import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.IOException;
import java.util.StringTokenizer;
import java.util.Queue;
import java.util.LinkedList;

public class Main {

    static int N;
    static int[][] grid;
    static boolean[][] visited;
    static int[][] dist;
    static int[] dr = {-1, 1, 0, 0};
    static int[] dc = {0, 0, -1, 1};

    static class Point {
        int r, c;

        Point(int r, int c) {
            this.r = r;
            this.c = c;
        }
    }

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        N = Integer.parseInt(br.readLine());

        grid = new int[N][N];
        visited = new boolean[N][N];
        dist = new int[N][N];

        for (int i = 0; i < N; i++) {
            StringTokenizer st = new StringTokenizer(br.readLine());
            for (int j = 0; j < N; j++) {
                grid[i][j] = Integer.parseInt(st.nextToken());
                dist[i][j] = -1;
            }
        }

        int islandId = 2;
        for (int i = 0; i < N; i++) {
            for (int j = 0; j < N; j++) {
                if (grid[i][j] == 1 && !visited[i][j]) {
                    labelIsland(i, j, islandId);
                    islandId++;
                }
            }
        }

        Queue<Point> queue = new LinkedList<>();

        for (int i = 0; i < N; i++) {
            for (int j = 0; j < N; j++) {
                if (grid[i][j] > 0) {
                    queue.add(new Point(i, j));
                    dist[i][j] = 0;
                }
            }
        }

        int minBridgeLength = Integer.MAX_VALUE;

        while (!queue.isEmpty()) {
            Point current = queue.poll();
            int r = current.r;
            int c = current.c;
            int currentIslandId = grid[r][c];

            for (int i = 0; i < 4; i++) {
                int nr = r + dr[i];
                int nc = c + dc[i];

                if (!isInBounds(nr, nc)) continue;

                if (grid[nr][nc] == 0) {
                    grid[nr][nc] = currentIslandId;
                    dist[nr][nc] = dist[r][c] + 1;
                    queue.add(new Point(nr, nc));
                } else if (grid[nr][nc] > 0 && grid[nr][nc] != currentIslandId) {
                    int bridgeLength = dist[r][c] + dist[nr][nc];
                    minBridgeLength = Math.min(minBridgeLength, bridgeLength);
                }
            }
        }

        System.out.println(minBridgeLength);
    }

    static void labelIsland(int startR, int startC, int id) {
        Queue<Point> q = new LinkedList<>();
        q.add(new Point(startR, startC));
        visited[startR][startC] = true;
        grid[startR][startC] = id;

        while (!q.isEmpty()) {
            Point current = q.poll();
            int r = current.r;
            int c = current.c;

            for (int i = 0; i < 4; i++) {
                int nr = r + dr[i];
                int nc = c + dc[i];

                if (isInBounds(nr, nc) && !visited[nr][nc] && grid[nr][nc] == 1) {
                    visited[nr][nc] = true;
                    grid[nr][nc] = id;
                    q.add(new Point(nr, nc));
                }
            }
        }
    }

    static boolean isInBounds(int r, int c) {
        return r >= 0 && r < N && c >= 0 && c < N;
    }
}
