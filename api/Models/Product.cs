using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Product
    {
        public Guid Id {get;set ;} = Guid.NewGuid();
        public string Name {get;set;} = string.Empty;
        public string Description {get;set;} = string.Empty;
        public decimal Price {get;set;}
        public int Count {get;set;}
        public int MinCount {get;set;}
        public decimal Tendetion {get;set;}

        public Guid VendingMachineId {get;set;}
        public VendingMachine? VendingMachine {get;set;}
    }
}