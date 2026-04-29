using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Service
    {
    public Guid Id {get;set ;} = Guid.NewGuid();
        public Guid VendingMachineId {get;set;}
        public VendingMachine? VendingMachine {get;set;}
        public DateTime Date {get;set;}
        public string Description {get;set;} = string.Empty;
        public string Error {get;set;} = string.Empty;
        public Guid UserId {get;set;}
        public User? User {get;set;}
    }
}