using ClassModels;
using ClassInterface;
using FileService;
namespace ClassServices
{
    public class PizzaService:IPizza
    {
        private IFileService _rw;
        string path=Path.Combine(Environment.CurrentDirectory, "File", "myFile.json");
        public DateTime Date { get; set; }
        protected List<Pizza> Pizzas { get; set; }
        public PizzaService(IFileService rw)
        {
             _rw=rw;
             Pizzas=_rw.Get<Pizza>(path);
             Date=DateTime.Now;
        }
        public List<Pizza> Get()
        {
            System.Console.WriteLine( "pizza: "+this.Date);
            Pizzas=_rw.Get<Pizza>(path);
            return Pizzas;
        }
        public Pizza? GetById(int id)
        {
            foreach (var pizza in Pizzas)
            {
                if (pizza.Id == id)
                {
                    return pizza;
                }
            }
            return null;
        }
        public bool UpDate(int id, Pizza p)
        {
            foreach (var pizza in Pizzas)
            {
                if (pizza.Id == id)
                {
                    pizza.Name = p.Name; 
                    pizza.Gluten = p.Gluten;
                     pizza.Price = p.Price;   
                    _rw.UpDate(Pizzas,path);
                    return true;
                }
            }
            return false;
        }
        public void AddPizza(Pizza p)
        {
             _rw.AddItem<Pizza>(p,path);
        }
        public List<Pizza>? Delete(int id)
        {
            foreach (var pizza in Pizzas)
            {
                if (pizza.Id == id)
                {
                    Pizzas.Remove(pizza);
                    _rw.UpDate(Pizzas,path);
                    return Pizzas;
                }
            }
            return null;
        }

    }
}
