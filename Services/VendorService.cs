using Siloam.Data;

namespace Siloam.Services;

public interface IVendorService
{ 
    List<Vendor> GetVendors(int pageNumber, int pageSize);
    List<Vendor> GetVendorsByUnitId(Guid unitId, int pageNumber, int pageSize);
    int GetTotalVendorCount();
    int GetTotalVendorCountByUnitId(Guid unitId);
    void AddVendor(Vendor vendor);
}

public class VendorService : IVendorService
{
    private readonly ApplicationDbContext _context;

    public VendorService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Vendor> GetVendorsByUnitId(Guid unitId, int pageNumber, int pageSize)
    {
        return _context.Vendors.Where(o => o.UnitId == unitId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }

    public List<Vendor> GetVendors(int pageNumber, int pageSize)
    {
        return _context.Vendors.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }
    
    public int GetTotalVendorCount()
    {
        return _context.Vendors.Count();
    }
    
    public int GetTotalVendorCountByUnitId(Guid unitId)
    {
        return _context.Vendors.Where(o => o.UnitId == unitId).Count();
    }

    public void AddVendor(Vendor vendor)
    {   
        _context.Vendors.Add(vendor);
        _context.SaveChanges();
    }
}