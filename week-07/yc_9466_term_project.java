import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.IOException;
import java.util.StringTokenizer;
import java.util.Queue;
import java.util.LinkedList;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringBuilder sb = new StringBuilder();

        int T = Integer.parseInt(br.readLine());

        while (T-- > 0) {
            int n = Integer.parseInt(br.readLine());

            int[] choice = new int[n + 1];
            int[] in_degree = new int[n + 1];

            StringTokenizer st = new StringTokenizer(br.readLine());
            for (int i = 1; i <= n; i++) {
                int v = Integer.parseInt(st.nextToken());
                choice[i] = v;
                in_degree[v]++;
            }

            Queue<Integer> q = new LinkedList<>();

            for (int i = 1; i <= n; i++) {
                if (in_degree[i] == 0) {
                    q.add(i);
                }
            }

            int failed_count = 0;

            while (!q.isEmpty()) {
                int u = q.poll();
                failed_count++;

                int v = choice[u];
                in_degree[v]--;

                if (in_degree[v] == 0) {
                    q.add(v);
                }
            }
            sb.append(failed_count).append('\n');
        }
        System.out.print(sb);
    }
}