using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FileService;
public class ReadAndWrite :IFileService
{
    
    public ReadAndWrite()
    {
    }
    
    public void Write(string message,string path)
    {
      
       if (File.Exists(path))
        {
            File.WriteAllText(path ,$" {message}       ");
        }
    }
 public void AddItem<T>(T item,string path)
 {
    string jsonFp=File.ReadAllText(path);
    var tList=JsonSerializer.Deserialize<List<T>>(jsonFp);
    tList.Add(item);
    jsonFp=JsonSerializer.Serialize(tList);
    Write(jsonFp,path);
 }
 public List<T> Get<T>(string path)
 {
   string jsonFp=File.ReadAllText(path);
   var tList=JsonSerializer.Deserialize<List<T>>(jsonFp);
    if(tList!=null){
       return tList;
    }
    return default(List<T>);

 }
 public void UpDate<T>(List<T> list,string path)
 {
    string jsonFp=JsonSerializer.Serialize(list);
    this.Write(jsonFp,path);
 }

}