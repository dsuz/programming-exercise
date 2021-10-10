using System;

/// <summary>
/// 問題: 複数のスペース区切りの整数を入力し、それらの平均値を小数点以下第２位まで出力するプログラムを作れ。整数の範囲は int の範囲（-2147483648～2147483647）とする。
/// 
/// [例]
/// 入力:
///     0 -18 52 -6 35 121
/// 出力: 
///     30.67
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("複数の整数をスペース区切りで入力してください。例: 0 -18 52 -6 35 121");
        string line = Console.ReadLine();
        int sum = 0;

        // 問題に対する回答となるプログラムを以下に作れ。
        sum = 0 - 18 + 52 - 6 + 35 + 121;
        Console.WriteLine(((float) sum / 6).ToString("F2"));    // 小数点以下第２位までに整形している

        Console.WriteLine("Hit Enter...");
        Console.ReadLine();
    }
}
