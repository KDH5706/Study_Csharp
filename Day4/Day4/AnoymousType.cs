using System;

namespace AnoymousType
{
    class MainApp
    {
        static void Main(string[] args)
        {
            //var : 약한 형식(컴파일러가 자동으로 타입을 지정함. 단, 지역변수로만 가능)
            var a = new { Name = "박상현", Age = 123 };
            Console.WriteLine($"Name : {a.Name}, Age : {a.Age}");

            var b = new { Subject = "수학", Scores = new int[] { 90, 80, 70, 60 } };

            Console.Write($"Subject = {b.Subject}, Score : ");
            foreach (var score in b.Scores)
                Console.Write($"{score} ");

            Console.WriteLine();
        }
    }
}
