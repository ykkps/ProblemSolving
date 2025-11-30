import java.io.*;
import java.util.*;

public class Main {
    static class Node {
        int x, y, broken;
        Node(int x, int y, int broken) {
            this.x = x;
            this.y = y;
            this.broken = broken;
        }
    }

    public static void main(String[] args) throws Exception {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());

        int N = Integer.parseInt(st.nextToken());
        int M = Integer.parseInt(st.nextToken());
        int K = Integer.parseInt(st.nextToken());

        int[][] map = new int[N][M];
        for (int i = 0; i < N; i++) {
            String line = br.readLine();
            for (int j = 0; j < M; j++) {
                map[i][j] = line.charAt(j) - '0';
            }
        }

        int[][][] dist = new int[N][M][K + 1];
        for (int[][] a : dist)
            for (int[] b : a)
                Arrays.fill(b, -1);

        Queue<Node> q = new LinkedList<>();
        q.offer(new Node(0, 0, 0));
        dist[0][0][0] = 1;

        int[] dx = {1, -1, 0, 0};
        int[] dy = {0, 0, 1, -1};

        while (!q.isEmpty()) {
            Node cur = q.poll();

            if (cur.x == N - 1 && cur.y == M - 1) {
                System.out.println(dist[cur.x][cur.y][cur.broken]);
                return;
            }

            for (int d = 0; d < 4; d++) {
                int nx = cur.x + dx[d];
                int ny = cur.y + dy[d];

                if (nx < 0 || ny < 0 || nx >= N || ny >= M) continue;

                if (map[nx][ny] == 0 && dist[nx][ny][cur.broken] == -1) {
                    dist[nx][ny][cur.broken] = dist[cur.x][cur.y][cur.broken] + 1;
                    q.offer(new Node(nx, ny, cur.broken));
                }

                if (map[nx][ny] == 1 && cur.broken < K && dist[nx][ny][cur.broken + 1] == -1) {
                    dist[nx][ny][cur.broken + 1] = dist[cur.x][cur.y][cur.broken] + 1;
                    q.offer(new Node(nx, ny, cur.broken + 1));
                }
            }
        }

        System.out.println(-1);
    }
}
