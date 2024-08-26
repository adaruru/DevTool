using System;

class Program
{
    static void Main(string[] args)
    {
        // 打印所有传入的参数
        Console.WriteLine("傳入參數:");
        foreach (var arg in args)
        {
            Console.WriteLine(arg);
        }

        // 处理特定参数
        if (args.Length > 0)
        {
            Console.WriteLine("地一個參數: " + args[0]);
        }
        else
        {
            Console.WriteLine("沒有參數");
        }
        Console.ReadLine();
    }
}