using System;

/// <summary>
/// 問題: 複数のスペース区切りの整数を入力し、それらの最大値と合計値を出力するプログラムを作れ。
/// 整数の範囲は -200 ~ 200、整数の数は 10 個までとする。
/// 
/// [例]
/// 入力:
///     0 -18 52 121 -6 35
/// 出力: 
///     121
///     184
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("複数の整数をスペース区切りで入力してください。例: 0 -18 52 121 -6 35");
        string line = Console.ReadLine();
        int max = int.MinValue;
        int sum = 0;

        // 問題に対する回答となるプログラムを以下に作れ。

        Console.WriteLine("Hit Enter...");
        Console.ReadLine();
    }
}
