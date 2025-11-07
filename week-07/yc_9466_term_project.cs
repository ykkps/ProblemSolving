using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        using (var reader = new StreamReader(Console.OpenStandardInput()))
        using (var writer = new StreamWriter(Console.OpenStandardOutput()))
        {
            StringBuilder sb = new StringBuilder();
            int T = int.Parse(reader.ReadLine());

            while (T-- > 0)
            {
                int n = int.Parse(reader.ReadLine());

                int[] choice = new int[n + 1];
                int[] in_degree = new int[n + 1];

                string[] inputs = reader.ReadLine().Split(' ');
                for (int i = 1; i <= n; i++)
                {
                    int v = int.Parse(inputs[i - 1]);
                    choice[i] = v;
                    in_degree[v]++;
                }

                Queue<int> q = new Queue<int>();

                for (int i = 1; i <= n; i++)
                {
                    if (in_degree[i] == 0)
                    {
                        q.Enqueue(i);
                    }
                }

                int failed_count = 0;

                while (q.Count > 0)
                {
                    int u = q.Dequeue();
                    failed_count++;

                    int v = choice[u];
                    in_degree[v]--;

                    if (in_degree[v] == 0)
                    {
                        q.Enqueue(v);
                    }
                }
                sb.AppendLine(failed_count.ToString());
            }
            writer.Write(sb.ToString());
        }
    }
}