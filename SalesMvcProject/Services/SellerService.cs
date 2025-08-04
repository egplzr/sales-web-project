using Microsoft.EntityFrameworkCore;
using SalesMvcProject.Data;
using SalesMvcProject.Models;
using SalesMvcProject.Services.Exceptions;

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

    public Seller FindById(int id)
    {
        var seller = _context.Seller
            .Include(seller => seller.Department)
            .FirstOrDefault(seller => seller.Id == id);
       
        return seller;
    }

    public void Remove(int id)
    {
        _context.Seller.Remove(FindById(id));
        _context.SaveChanges();
    }

    public void Update(Seller obj)
    {
        if (!_context.Seller.Any(seller => seller.Id == obj.Id))
        {
            throw new NotFoundException("Id not found");
        }

        try
        {
            _context.Update(obj);
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException e)
        {
            throw new DbConcurrencyException(e.Message);
        }
    }
}