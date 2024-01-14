using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace  FileService;
   public interface  ILog 
   {
     string filePath { get; set; }
    
     void WriteMessage<T>(T message);
   } 