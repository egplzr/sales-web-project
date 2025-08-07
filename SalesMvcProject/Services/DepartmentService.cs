using Microsoft.EntityFrameworkCore;
using SalesMvcProject.Data;
using SalesMvcProject.Models;

namespace SalesMvcProject.Services;

public class DepartmentService(SalesMvcProjectContext context)
{
    private readonly SalesMvcProjectContext _context = context;

    public async Task<List<Department>> FindAllAsync()
    {
        return await _context.Department.OrderBy(x => x.Name).ToListAsync();
    }
}