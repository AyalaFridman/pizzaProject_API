namespace  FileService;

   public interface  IFileService
   {
     void Write(string message,string path);
     void AddItem<T>(T item,string path);
     List<T> Get<T>(string path);
     void UpDate<T>(List<T> l,string path);
   } 
