using System;
using System.Text;
using System.Collections.Generic;

record Tower(int Index, int Height);

public class Yc2493
{
    static void Main(string args[])
    {
        int n = int.Parse(Console.ReadLine());
        int[] towers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        StringBuilder sb = new StringBuilder();

        Stack<Tower> stack = new Stack<Tower>();

        for (int i = 0; i < n; i++)
        {
            int height = towers[i];

            while(stack.Count > 0 && stack.Peek().Height < height)
            {
                stack.Pop();
            }

            if (stack.Count > 0)
            {
                sb.Append(stack.Peek().Index).Append(" ");
            }
            else
            {
                sb.Append("0 ");
            }

            stack.Push(new Tower(i + 1, height));
        }
        Console.WriteLine(sb.ToString().Trim());
    }
}
