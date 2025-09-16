import java.io.*;
import java.util.*;

public class Main {

	record Element(int Index, int Value) {}

	public static void main(String[] args) {
		BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

		int n = Integer.parseInt(br.readLine());
		int[] arr = Arrays.stream(br.readLine().split(" ")).mapToInt(Integer::parseInt)
		int[] answer = new int[n];

		Stack<Element> stack = new Stack<>();

		for(int i = 0; i < n; i++) {
			int value = arr[i];

			while(!stack.isEmpty() && stack.peek().Value() <value) {
				Element e = stack.pop();
				answer[e.Index()] = value;
			}
			stack.push(new Element(i, value));
		}

		while(!stack.isEmpty()) {
			answer[stack.pop().Index()] = -1;
		}

		StringBuilder sb = new StringBuilder();
		int i = 0;
		while (i < answer.length) {
            sb.append(answer[i]).append(" ");
            i++;
        }
		System.out.println(sb.toString().trim());
	}
}
