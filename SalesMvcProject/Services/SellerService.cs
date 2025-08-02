using SalesMvcProject.Data;
using SalesMvcProject.Models;

namespace SalesMvcProject.Services;

public class SellerService(SalesMvcProjectContext context)
{
    private readonly SalesMvcProjectContext _context = context;

    public List<Seller> FindAll()
    {
        return _context.Seller.ToList();
    }

    public void Insert(Seller obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }
}