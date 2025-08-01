﻿namespace SalesMvcProject.Models;

public class Seller
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public double BaseSalary { get; set; }
    public Department Department { get; set; }
    public int DepartmentId { get; set; }
    public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

    public Seller()
    {
    }
    
    public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthDate;
        BaseSalary = baseSalary;
        Department = department;
    }
    
    public void AddSales(SalesRecord salesRecord)
    {
        SalesRecords.Add(salesRecord);
    }

    public void RemoveSales(SalesRecord salesRecord)
    {
        SalesRecords.Remove(salesRecord);
    }

    public double TotalSales(DateTime initialDate, DateTime finalDate)
    {
        var totalSales = this.SalesRecords
            .Where(sale => sale.Date >= initialDate && sale.Date <= finalDate)
            .Sum(sale => sale.Amount);
        
        return totalSales;
    }
}