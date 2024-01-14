using ClassModels;
namespace ClassInterface
{
    public interface IPizza
    {
        DateTime Date { get; set; }
        List<Pizza> Get();
        Pizza? GetById(int id);
        bool UpDate(int id, Pizza pizza);
        void AddPizza(Pizza p);
        List<Pizza>? Delete(int id) ;
    }

}
