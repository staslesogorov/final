using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models;

public class VendingMachine
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string SerialNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Place { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Coordinates { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Operator { get; set; } = string.Empty;
    public string PaymentType { get; set; } = string.Empty;
    public string WorkMode { get; set; } = string.Empty;
    public string WorkingHours { get; set; } = string.Empty;
    public string Timezone { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public DateTime ServiceDate { get; set; }
    public decimal Earning { get; set; }
}
  