import java.io.*;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringBuffer sb = new StringBuffer();

        int testCase = Integer.parseInt(br.readLine());

        while(testCase > 0) {
            String commands = br.readLine();
            int n = Integer.parseInt(br.readLine());
            String arrStr = br.readLine();

            arrStr = arrStr.substring(1, arrStr.length() -1);
            Deque<Integer> dq = new ArrayDeque<>();
            if(!arrStr.isEmpty()) {
                String[] parts = arrStr.split(",");
                for(String p : parts) dq.addLast(Integer.parseInt(p));
            }
            boolean isForwardDirection = true;
            boolean isError = false;

            for(char c: commands.toCharArray()) {
                if(c == 'R') {
                    isForwardDirection = !isForwardDirection;
                } else if(c == 'D') {
                    if(dq.isEmpty()) {
                        isError = true;
                        break;
                    }
                    if(!isForwardDirection) {
                        dq.removeLast();
                    }
                    else {
                        dq.removeFirst();
                    }
                }
            }

            if (isError) {
                sb.append("error\n");
            }
            else {
                sb.append("[");
                if(!dq.isEmpty()) {
                    if(!isForwardDirection) {
                        Iterator<Integer> it = dq.descendingIterator();
                        while(it.hasNext()) {
                            sb.append(it.next());
                            if(it.hasNext()) {
                                sb.append(",");
                            }
                        }
                    }
                    else {
                        Iterator<Integer> it = dq.iterator();
                        while(it.hasNext()) {
                            sb.append(it.next());
                            if(it.hasNext()) {
                                sb.append(",");
                            }
                        }
                    }
                }
                sb.append("]\n");
            }
            testCase--;
        }
        System.out.println(sb.toString());
    }
}