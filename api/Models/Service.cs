using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Service
    {
        public int Id {get;set;}
        public int VendingMachineId {get;set;}
        public VendingMachine? VendingMachine {get;set;}
        public DateTime Date {get;set;}
        public string Description {get;set;} = string.Empty;
        public string Error {get;set;} = string.Empty;
        public int UserId {get;set;}
        public User? User {get;set;}
    }
}