using System;
using System.Collections.Generic;

namespace ClassModels
{
    public class Order
    {
        public int Id{get;set;}
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public int TotalAmount { get; set; }
        public List<int> Items { get; set; }
        public List<int> AmountItems{get; set;}
        public PaymentDetails CreditPaymentDetails{get;set;}
    }

}