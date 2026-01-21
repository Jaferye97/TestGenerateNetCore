using Domain.Models.Supplier;

namespace Application.Ports.RepositoryEntityFrameworkSqlServer;

public interface ISupplierAttributeRepositoryPort
{
    Task<IEnumerable<SupplierAttributeModel>> AddSupplierAttributeAsync(IEnumerable<SupplierAttributeModel> models);
    Task UpdateSupplierAttributeAsync(IEnumerable<SupplierAttributeModel> models);
}
