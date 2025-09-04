import java.util.Stack;
import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Yc1874 {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int stackSize = Integer.parseInt(br.readLine());
        StringBuilder answer = new StringBuilder();
        boolean resultAvailable = true;
        int valueToPush = 1;
        Stack<Integer> stack = new Stack<>();

        for (int i = 0; i < stackSize; i++) {
            int currentNumber = Integer.parseInt(br.readLine());

            while (valueToPush <= currentNumber) {
                stack.push(valueToPush++);
                answer.append("+\n");
            }

            if (stack.peek() == currentNumber) {
                stack.pop();
                answer.append("-\n");
            } else {
                resultAvailable = false;
            }
        }

        if (resultAvailable) {
            System.out.println(answer);
        } else {
            System.out.println("NO");
        }
    }
}