using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        StringBuilder sb = new StringBuilder();

        int[] q = new int[n];
        int front = 0;
        int back = 0;

        for (int i = 0; i < n; i++)
        {
            string[] cmd = Console.ReadLine().Split();

            switch(cmd[0])
            {
                case "push":
                    q[back++] = int.Parse(cmd[1]);
                    break;
                case "pop":
                    sb.Append(front == back ? -1 : q[front++]).Append('\n');
                    break;
                case "size":
                    sb.Append(back - front).Append('\n');
                    break;
                case "empty":
                    sb.Append(front == back ? 1 : 0).Append('\n');
                    break;
                case "front":
                    sb.Append(front == back ? -1 : q[front]).Append('\n');
                    break;
                case "back":
                    sb.Append(front == back ? -1 : q[back - 1]).Append('\n');
                    break;
            }
        }
        Console.Write(sb.ToString());
    }
}
