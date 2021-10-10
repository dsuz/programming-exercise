using System;

/// <summary>
/// 問題: 整数 N が入力される。入力された N に対して、素数かどうかを判定し、結果を出力せよ。
///
/// 素数の定義は以下を両方とも満たす整数とする。
/// 
/// a. 1 より大きい整数である
/// b. 1 と自分自身以外の正の整数では割り切れない
/// 
/// 入力された整数 N が素数である場合は「素数」、そうでない場合は「素数ではない」と出力せよ。
/// N の範囲は 1 ~ 1000 とする。
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("整数を入力してください。例: 6");
            string line = Console.ReadLine();
            int num = int.Parse(line);

            if (IsPrime(num))
            {
                Console.WriteLine($"{num} は素数");
            }
            else
            {
                Console.WriteLine($"{num} は素数ではない");
            }
        }
    }

    static bool IsPrime(int n)
    {
        // 問題に対する回答となるプログラムを以下に作れ。
        return false;
    }
}
