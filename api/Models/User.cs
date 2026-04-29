using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class User
    {
        public Guid Id {get;set ;} = Guid.NewGuid();
        public string Photo {get;set;} = string.Empty;
        public string Login {get;set;} = string.Empty;
        public string Password {get;set;} = string.Empty;
        public string FullName {get;set;} = string.Empty;
        public string Email {get;set;} = string.Empty;
        public string Phone {get;set;} = string.Empty;
        public string Role {get;set;} = string.Empty;
    }
}