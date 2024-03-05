using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Siloam.Data;

public class Vendor
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public Guid UnitId { get; set; }
    public Unit Unit { get; set; }
}