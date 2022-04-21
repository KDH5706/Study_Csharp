using System;

namespace Day2
{
    interface ILogger
    {
        void WriteLog(string message);  //ILogger를 상속받는 클래스들은 WriteLog 메소드를 무조건 정의해야한다.
        void WriteError(string error)
        {
            WriteLog($"Error: {error}");
        }
    }

    class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine(
                $"{ DateTime.Now.ToLocalTime()}, { message}");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            logger.WriteLog("System Up");
            logger.WriteError("System Fail");

            ConsoleLogger clogger = new ConsoleLogger();
            clogger.WriteLog("System Up");
            //clogger.WriteError("System Fail");
        }
    }
}
