using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int l = int.Parse(input[1]);

        var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        LinkedList<(int value, int index)> dq = new LinkedList<(int, int)>();
        StringBuilder sb = new StringBuilder();

        for(var i = 0; i < n; i++)
        {
            int num = arr[i];

            while(dq.Count > 0 && dq.Last.Value.value > num)
            {
                dq.RemoveLast();
            }
            dq.AddLast((num, i));

            if(dq.First.Value.index <= i - l)
            {
                dq.RemoveFirst();
            }

            sb.Append(dq.First.Value.value).Append(' ');
        }
        Console.WriteLine(sb.ToString());
    }
}