using System;
using System.Collections.Generic;

record Building(int Index, int Height);

class Yc6198
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long answer = 0;
        Stack<Building> stack = new Stack<Building>();

        for (int i = 0; i < n; i++)
        {
            int height = int.Parse(Console.ReadLine());

            while (stack.Count > 0 && stack.Peek().Height <= height)
            {
                stack.Pop();
            }

            answer += stack.Count;

            stack.Push(new Building(i, height));
        }
        Console.WriteLine(answer);
    }
}