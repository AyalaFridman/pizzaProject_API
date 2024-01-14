using ClassModels;
using ClassInterface;
using FileService;
namespace ClassServices
{
    public class WorkerService:IWorker
    {
        private IFileService _rw;
        string path=Path.Combine(Environment.CurrentDirectory, "File", "workers.json");
        public DateTime Date { get; set; }
        public List<Worker> Workers { get; set; }
        static int id = 1;
        public WorkerService(IFileService rw)
        {
            this.Date=DateTime.Now;
            _rw=rw;
            Workers=_rw.Get<Worker>(path);
        }
        public List<Worker> Get()
        {
            System.Console.WriteLine("worker: "+this.Date);
            Workers=_rw.Get<Worker>(path);
            return Workers;
        }
        public void AddWorker(Worker w)
        {
            id++;
            w.Id=id;
             _rw.AddItem<Worker>(w,path);
        }
        public List<Worker>? Delete(int id)
        {
            foreach (var w in Workers)
            {
                if (w.Id == id)
                {
                    Workers.Remove(w);
                    _rw.UpDate(Workers,path);
                    return Workers;
                }
            }
            return null;
        }
        // public string PrintRole(Worker w){
        //     return w.Role;
        // }
    }
}

