using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        var testCase = int.Parse(Console.ReadLine());
        var sb = new StringBuilder();

        while(testCase > 0)
        {
            string commands = Console.ReadLine();
            var n = int.Parse(Console.ReadLine());
            string arrStr = Console.ReadLine();

            arrStr = arrStr.Substring(1, arrStr.Length - 2);
            var dq = new LinkedList<int>();
            if(!string.IsNullOrEmpty(arrStr))
            {
                foreach(var s in arrStr.Split(","))
                {
                    dq.AddLast(int.Parse(s));
                }
            }
            bool isForwardDirection = true;
            bool error = false;

            foreach(char c in commands)
            {
                if(c == 'R')
                {
                    isForwardDirection = !isForwardDirection;
                }
                else if(c == 'D')
                {
                    if(dq.Count == 0)
                    {
                        error = true;
                        break;
                    }
                    if(!isForwardDirection)
                    {
                        dq.RemoveLast();
                    }
                    else
                    {
                        dq.RemoveFirst();
                    }
                }
            }

            if(error)
            {
                sb.AppendLine("error");
            }
            else
            {
                sb.Append("[");
                if(dq.Count > 0)
                {
                    if(!isForwardDirection)
                    {
                        var node = dq.Last;
                        while(node != null)
                        {
                            sb.Append(node.Value);
                            node = node.Previous;
                            if(node != null)
                            {
                                sb.Append(",");
                            }
                        }
                    }
                    else
                    {
                        var node = dq.First;
                        while(node != null)
                        {
                            sb.Append(node.Value);
                            node = node.Next;
                            if(node != null)
                            {
                                sb.Append(",");
                            }
                        }
                    }
                }
                sb.AppendLine("]");
            }
            testCase--;
        }
        Console.Write(sb.ToString());
    }
}