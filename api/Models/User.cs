using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class User
    {
        public int Id {get;set;}
        public string FIO {get;set;} = string.Empty;
        public string Email {get;set;} = string.Empty;
        public string Phone {get;set;} = string.Empty;
        public string Role {get;set;} = string.Empty;
    }
}