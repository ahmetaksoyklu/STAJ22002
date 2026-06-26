namespace Application.Features.Products.Commands.Create;

public class CreatedProductResponse
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public short UnitsInStock { get; set; }
    public decimal UnitPrice { get; set; }
}
