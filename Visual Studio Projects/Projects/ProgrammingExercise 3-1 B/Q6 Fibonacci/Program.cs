using System;

/// <summary>
/// 問題: 整数 N が入力される。入力された N に対して、N 番目のフィボナッチ数を求め、出力せよ。
///
/// フィボナッチ数の定義は以下とする。
/// 
/// a. 0 番目のフィボナッチ数は 0 である
/// b. 1 番目のフィボナッチ数は 1 である
/// c. 2 番目以降のフィボナッチ数は、直前の 2 つのフィボナッチ数の和である
/// 
/// つまり、n 番目（ただし、n >= 2 とする）のフィボナッチ数を Fn とすると、以下の式が成り立つ。
/// 
///     Fn = Fn-1 + Fn-2
///     
/// N の範囲は 0 ~ 20 とする。
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
            Console.WriteLine(Fibonacci(num));
        }
    }

    static int Fibonacci(int num)
    {
        // 問題に対する回答となるプログラムを以下に作れ。
        if (num == 0)
        {
            return 0;
        }
        else if (num == 1)
        {
            return 1;
        }

        return num;
    }
}
