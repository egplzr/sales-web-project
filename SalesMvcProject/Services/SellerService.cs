using Microsoft.EntityFrameworkCore;
using SalesMvcProject.Data;
using SalesMvcProject.Models;
using SalesMvcProject.Services.Exceptions;

namespace SalesMvcProject.Services;

public class SellerService(SalesMvcProjectContext context)
{
    private readonly SalesMvcProjectContext _context = context;

    public async Task<List<Seller>> FindAllAsync()
    {
        return await _context.Seller.ToListAsync();
    }

    public async Task InsertAsync(Seller obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
    }

    public async Task<Seller> FindByIdAsync(int id)
    {
        var seller = await _context.Seller
            .Include(seller => seller.Department)
            .FirstOrDefaultAsync(seller => seller.Id == id);
       
        return seller;
    }

    public async Task RemoveAsync(int id)
    {
        _context.Seller.Remove(await FindByIdAsync(id));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Seller obj)
    {
        bool hasAny = await _context.Seller.AnyAsync(seller => seller.Id == obj.Id);
        if (!hasAny)
        {
            throw new NotFoundException("Id not found");
        }

        try
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            throw new DbConcurrencyException(e.Message);
        }
    }
}