namespace SalesMvcProject.Services.Exceptions;

public class DbConcurrencyException(string message) : ApplicationException(message)
{
    
}