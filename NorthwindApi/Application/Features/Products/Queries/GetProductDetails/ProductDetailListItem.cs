namespace Application.Features.Products.Queries.GetProductDetails;

public class ProductDetailListItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public short UnitsInStock { get; set; }
}
