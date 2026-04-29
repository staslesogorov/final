using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Sale
    {
        public Guid Id {get;set ;} = Guid.NewGuid();

        public Guid VendingMachineId {get;set;}
        public VendingMachine? VendingMachine {get;set;}
        public Guid ProductId {get;set;}
        public Product? Product {get;set;}
        public int Count {get;set;}
        public decimal Earning {get;set;}
        public DateTime Date {get;set;}
        public string PaymentMethod {get;set;} = string.Empty;
    }
}