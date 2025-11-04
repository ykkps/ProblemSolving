import java.io.*;
import java.util.*;

public class Main {
    static int N, M;
    static int[][] map;
    static int[][][] visited;
    static int[] dx = {1, -1, 0, 0};
    static int[] dy = {0, 0, 1, -1};

    static class Node {
        int x, y, broken;

        Node(int x, int y, int broken) {
            this.x = x;
            this.y = y;
            this.broken = broken;
        }
    }

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        N = Integer.parseInt(st.nextToken());
        M = Integer.parseInt(st.nextToken());
        map = new int[N][M];
        visited = new int[N][M][2];

        for (int i = 0; i < N; i++) {
            String line = br.readLine();
            for (int j = 0; j < M; j++) {
                map[i][j] = line.charAt(j) - '0';
            }
        }

        System.out.println(bfs());
    }

    static int bfs() {
        Queue<Node> q = new LinkedList<>();
        q.add(new Node(0, 0, 0));
        visited[0][0][0] = 1;

        while (!q.isEmpty()) {
            Node cur = q.poll();
            int x = cur.x, y = cur.y, broken = cur.broken;

            if (x == N - 1 && y == M - 1) {
                return visited[x][y][broken];
            }

            for (int i = 0; i < 4; i++) {
                int nx = x + dx[i];
                int ny = y + dy[i];

                if (nx < 0 || ny < 0 || nx >= N || ny >= M) continue;

                if (map[nx][ny] == 0 && visited[nx][ny][broken] == 0) {
                    visited[nx][ny][broken] = visited[x][y][broken] + 1;
                    q.add(new Node(nx, ny, broken));
                } else if (map[nx][ny] == 1 && broken == 0 && visited[nx][ny][1] == 0) {
                    visited[nx][ny][1] = visited[x][y][broken] + 1;
                    q.add(new Node(nx, ny, 1));
                }
            }
        }
        return -1;
    }
}
