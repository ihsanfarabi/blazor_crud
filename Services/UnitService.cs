using Siloam.Data;

namespace Siloam.Services;

public interface IUnitService
{
    Unit AddUnit(string unitName);
    List<Unit> GetUnits();
}

public class UnitService : IUnitService
{
    private readonly ApplicationDbContext _context;

    public UnitService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public List<Unit> GetUnits()
    {
        return _context.Units.ToList();
    }

    public Unit AddUnit(string unitName)
    {
        var newUnit = _context.Units.SingleOrDefault(p => p.Name == unitName);
        
        if (newUnit == null)
        {
            newUnit = new Unit
            {
                Name = unitName
            };
            
            _context.Units.Add(newUnit);
        }

        _context.SaveChanges();

        return newUnit;
    }
}