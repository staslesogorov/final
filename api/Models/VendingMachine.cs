using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models;

public class VendingMachine
{
    public Guid Id {get;set ;} = Guid.NewGuid();
    public string Place {get;set;} = string.Empty;
    public string Model {get;set;} = string.Empty;
    public string Type {get;set;} = string.Empty;
    public string Status {get;set;} = string.Empty;
    public DateTime Date {get;set;}
    public DateTime ServiceDate {get;set;}
    public decimal Earning {get;set;}

}
  