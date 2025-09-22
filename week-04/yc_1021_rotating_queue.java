import java.io.*;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());
        int n = Integer.parseInt(st.nextToken());
        int m = Integer.parseInt(st.nextToken());

        ArrayDeque<Integer> dq = new ArrayDeque<>();
        for (int i = 1; i <= n; i++) {
            dq.addLast(i);
        }

        String[] targetStr = br.readLine().split(" ");
        int[] targets = Arrays.stream(targetStr).mapToInt(Integer::parseInt).toArray();

        int result = 0;

        for (int target : targets) {
            int index = 0;
            for (int val : dq) {
                if (val == target) break;
                index++;
            }

            int leftDistance = index;
            int rightDistance = dq.size() - index;

            if (leftDistance > rightDistance) {
                for (int i = 0; i < rightDistance; i++) {
                    dq.addFirst(dq.removeLast());
                    result++;
                }
            } else {
                for (int i = 0; i < leftDistance; i++) {
                    dq.addLast(dq.removeFirst());
                    result++;
                }
            }
            dq.removeFirst();
        }

        System.out.println(result);
    }
}
