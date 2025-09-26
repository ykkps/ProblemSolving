import java.io.*;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());

        int n = Integer.parseInt(st.nextToken());
        int l = Integer.parseInt(st.nextToken());

        st = new StringTokenizer(br.readLine());
        Deque<int[]> dq = new ArrayDeque<>();
        StringBuilder sb = new StringBuilder();

        for(int i = 0; i < n; i++) {
            int num = Integer.parseInt(st.nextToken());

            while(!dq.isEmpty() && dq.peekLast()[0] > num) {
                dq.pollLast();
            }
            dq.addLast(new int[]{num, i});

            if(dq.peekFirst()[1] <= i - l) {
                dq.pollFirst();
            }

            sb.append(dq.peekFirst()[0]).append(" ");
        }
        System.out.println(sb);
    }
}