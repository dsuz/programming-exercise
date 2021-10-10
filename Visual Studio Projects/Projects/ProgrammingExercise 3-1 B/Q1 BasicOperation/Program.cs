using System;

/// <summary>
/// 問題: ２つのスペース区切りの整数を入力し、それらの和・差・積を求めて出力するプログラムを作れ。
/// 
/// [例]
/// 入力:
///     4 5
/// 出力: 
///     9
///     -1
///     20
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("２つの整数をスペース区切りで入力してください。例: 4 5");
        string line = Console.ReadLine();
        var inputs = line.Split(' ');
        int a = int.Parse(inputs[0]);
        int b = int.Parse(inputs[1]);

        // 問題に対する回答となるプログラムを以下に作れ。
        Console.WriteLine(a);
        Console.WriteLine(b);

        Console.WriteLine("Hit Enter...");
        Console.ReadLine();
    }
}
