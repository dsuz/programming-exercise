using System;

/// <summary>
/// 問題: 整数 N が入力される。入力された N に対して、以下のルールで出力せよ。
/// 
/// 1. N が 3 で割り切れる場合は Fizz を出力する
/// 2. N が 5 で割り切れる場合は Buzz を出力する
/// 3. N が 3 と 5 の両方で割り切れる場合は FizzBuzz を出力する
/// 4. N が 3 でも 5 でも割り切れない場合は、入力された N をそのまま出力する
/// 
/// N の範囲は int の範囲（-2147483648～2147483647）とする。
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
            Console.WriteLine(Fizzbuzz(num));
        }
    }

    static string Fizzbuzz(int num)
    {
        // 問題に対する回答となるプログラムを以下に作れ。
        return "Fizzbuzz";
    }
}
