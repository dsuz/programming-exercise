using System;

/// <summary>
/// 問題: 複数のスペース区切りの整数を入力し、それらの最小値を出力するプログラムを作れ。整数の範囲は int の範囲（-2147483648～2147483647）とする。
/// 
/// [例]
/// 入力:
///     0 -18 52 -6 35 121
/// 出力: 
///     -18
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("複数の整数をスペース区切りで入力してください。例: 0 -18 52 -6 35 121");
        string line = Console.ReadLine();
        int min = int.MaxValue;

        // 問題に対する回答となるプログラムを以下に作れ。

        Console.WriteLine("Hit Enter...");
        Console.ReadLine();
    }
}
