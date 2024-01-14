using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace FileService;

public class LogService:ILog
{
    public string filePath{get;set;}

    public LogService()
    {
        this.filePath=Path.Combine(Environment.CurrentDirectory,"File","fileLog.txt");
    }
    public void WriteMessage<T>(T message)
    {
        if(File.Exists(filePath))
        {
            File.AppendAllText(filePath,$"{message}  ");
            System.Console.WriteLine();
        }
    }
}
