namespace Domain.Models.Supplier;

[ExcludeFromCodeCoverage]
public class SupplierFilterModel : FilterModel
{
    public string TaxId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

