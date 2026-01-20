namespace Domain.Models.Commons;

[ExcludeFromCodeCoverage]
public class FilterModel
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
