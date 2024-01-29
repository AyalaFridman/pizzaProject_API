
using ClassModels;
using ClassInterface;
using FileService;
using System.Text;
using System.Text.Json;
namespace ClassServices
{
    public class OrderService:IOrder
    {
        private IFileService _rw;
        string path=Path.Combine(Environment.CurrentDirectory, "File", "order.json");
        public DateTime Date { get; set; }
        public List<Order> Orderes { get; set; }
        public OrderService(IFileService rw)
        {
            this.Date=DateTime.Now;
            _rw=rw;
            Orderes=_rw.Get<Order>(path);
        }
        public List<Order> Get()
        {
            System.Console.WriteLine("order: "+this.Date);
            Orderes=_rw.Get<Order>(path);
            return Orderes;
        }
        // public void UpDateOrder(Order o)
        // {
        //     o.Date=this.Date;
        //     Orderes[o.Id]=o;
        //     Orderes[o.Id].Phone=o.Phone;
        //      _rw.UpDate<Order>(Orderes,path);
        //     System.Console.WriteLine(Orderes.Count);
        // }
        public async void AddOrder(Order o)
        {
            var pathP=Path.Combine(Environment.CurrentDirectory, "File", "pizza.json");
            var pizzaList=_rw.Get<Pizza>(pathP);
            System.Console.WriteLine(o.Items.Last());
            for(var i=0;i<o.Items.Last();i++){
             foreach (var p in pizzaList)
               {
                if(p.Id==o.Items[i])
                {
                    o.TotalAmount+=(p.Price*o.AmountItems[i]);                   
                }

                }
               }
            
        o.Date=this.Date;
         _rw.AddItem<Order>(o,path);
         Task<Order> t=payment(o);
         makingPizza();
         Order ord=await t;
         SendingInvoice(ord);
        //  this.SendingInvoice();
        }
        // public void AddPizzaToOrder(int idOrder,int idPizza,int amount)
        // {
        //     var pathP=Path.Combine(Environment.CurrentDirectory, "File", "pizza.json");
        //      System.Console.WriteLine(pathP);
        //     var pizzaList=_rw.Get<Pizza>(pathP);
        //      System.Console.WriteLine(pizzaList);
        //      foreach (var p in pizzaList)
        //        {
        //         if(p.Id==idPizza)
        //         {
        //             if(Orderes[idOrder].Items==null)
        //             {
        //                 Orderes[idOrder].Items=new List<int>();
        //             }
        //             if(Orderes[idOrder].AmountItems==null)
        //             {
        //                 Orderes[idOrder].AmountItems= new List<int>();
        //             }
        //            System.Console.WriteLine(p);
        //            Orderes[idOrder].Items.Add(idPizza);
        //           Orderes[idOrder].AmountItems.Add(amount);
        //           Orderes[idOrder].TotalAmount+=(p.Price*amount);
        //            System.Console.WriteLine( Orderes[idOrder].TotalAmount);
        //           _rw.UpDate(Orderes,path);
        //         }
        //        }
        // }
        public async Task<Order> payment(Order o)
        {
            await Task.Delay(5000);
             System.Console.WriteLine( "התשלום בוצע בהצלחה");
            // string path=Path.Combine(Environment.CurrentDirectory, "File", "payment.txt");
            // string paymentDetailsString=JsonSerializer.Serialize(paymentDetails);
            // _rw.Write(paymentDetailsString,path);
            return o;
        }
        public void makingPizza ()
        {
             System.Console.WriteLine( "the pizza is complited");
        }
        public void SendingInvoice(Order o)
        {
            System.Console.WriteLine("SendingInvoice");
            string path=Path.Combine(Environment.CurrentDirectory, "Mail", "mail.json");
            string orderString=JsonSerializer.Serialize(o);
            _rw.Write(orderString,path);
        }

    }
}
