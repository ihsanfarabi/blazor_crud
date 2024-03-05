using System.ComponentModel.DataAnnotations.Schema;

namespace Siloam.Data;

public class Unit
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<Vendor> Vendors { get; set; }
}
