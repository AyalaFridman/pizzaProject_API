using System;
using System.Collections.Generic;

namespace ClassModels
{
    public class Order
    {
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public int TotalAmount { get; set; }
        public List<Pizza> Items { get; set; }

        public Order()
        {
            Items = new List<Pizza>();
        }
    }
}