namespace Domain.Entities;

public class Product : Entity<int>
{
    public int CategoryId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public short UnitsInStock { get; set; }
    public decimal UnitPrice { get; set; }
}
