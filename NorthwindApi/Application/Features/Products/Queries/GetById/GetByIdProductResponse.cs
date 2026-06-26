namespace Application.Features.Products.Queries.GetById;

public class GetByIdProductResponse
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public short UnitsInStock { get; set; }
    public decimal UnitPrice { get; set; }
}
