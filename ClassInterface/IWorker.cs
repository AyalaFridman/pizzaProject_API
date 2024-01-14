using ClassModels;
namespace ClassInterface
{
    public interface IWorker
    {
        public DateTime Date { get; set; }
        public void AddWorker(Worker w);
        public List<Worker> Get();
        public List<Worker>? Delete(int id);
        // public string PrintRole(Worker w);
    }
}
