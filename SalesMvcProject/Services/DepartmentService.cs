using SalesMvcProject.Data;
using SalesMvcProject.Models;

namespace SalesMvcProject.Services;

public class DepartmentService(SalesMvcProjectContext context)
{
    private readonly SalesMvcProjectContext _context = context;

    public List<Department> FindAll()
    {
        return _context.Department.OrderBy(x => x.Name).ToList();
    }
}