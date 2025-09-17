import java.io.*;
import java.util.*;

public class Main {
    record Person(int height, long count) {}

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int N = Integer.parseInt(br.readLine());

        Stack<Person> stack = new Stack<>();
        long result = 0;

        for (int i = 0; i < N; i++) {
            int h = Integer.parseInt(br.readLine());
            long count = 1;

            while (!stack.isEmpty() && stack.peek().height() < h) {
                result += stack.peek().count();
                stack.pop();
            }

            if (!stack.isEmpty() && stack.peek().height() == h) {
                Person top = stack.pop();
                result += top.count();
                count = top.count() + 1;

                if (!stack.isEmpty()) {
                    result += 1;
                }
            } else {
                if (!stack.isEmpty()) {
                    result += 1;
                }
            }

            stack.push(new Person(h, count));
        }

        System.out.println(result);
    }
}
