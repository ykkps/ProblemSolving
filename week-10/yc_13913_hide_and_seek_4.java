import java.io.*;
import java.util.*;

public class Main {
    static final int MAX = 100000;
    static int[] dist = new int[MAX + 1];
    static int[] prev = new int[MAX + 1];

    public static void main(String[] args) throws Exception {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        int N = Integer.parseInt(st.nextToken());
        int K = Integer.parseInt(st.nextToken());

        Arrays.fill(dist, -1);
        Arrays.fill(prev, -1);

        bfs(N, K);

        List<Integer> path = new ArrayList<>();
        for (int cur = K; cur != -1; cur = prev[cur]) {
            path.add(cur);
        }
        Collections.reverse(path);

        StringBuilder sb = new StringBuilder();
        sb.append(dist[K]).append("\n");
        for (int p : path) sb.append(p).append(" ");
        System.out.println(sb);
    }

    static void bfs(int N, int K) {
        Queue<Integer> q = new LinkedList<>();
        q.offer(N);
        dist[N] = 0;

        while (!q.isEmpty()) {
            int x = q.poll();

            if (x == K) return;

            int[] nexts = {x - 1, x + 1, x * 2};

            for (int nx : nexts) {
                if (nx >= 0 && nx <= MAX && dist[nx] == -1) {
                    dist[nx] = dist[x] + 1;
                    prev[nx] = x;
                    q.offer(nx);
                }
            }
        }
    }
}
