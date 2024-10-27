using System.IO;
using System;

namespace Delivery.Core;

public class LogWriter
{
    private static readonly LogWriter instance = new LogWriter();
    private static readonly object lockObject = new object();
    public static LogWriter I => instance;

    public LogWriter()
    {
        try
        {
            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");
            if (!File.Exists("logs/logs.txt")) File.Create("logs/logs.txt").Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void WriteLog(string logMessage)
    {
        try
        {
            lock (lockObject) // Используем блокировку файла
            {
                using (StreamWriter sw = File.AppendText("logs/logs.txt"))
                {
                    Console.WriteLine(logMessage);
                    sw.Write("\r\nLog Entry : ");
                    sw.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                        DateTime.Now.ToLongDateString());
                    sw.WriteLine("  :{0}", logMessage);
                    sw.WriteLine("-------------------------------");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
