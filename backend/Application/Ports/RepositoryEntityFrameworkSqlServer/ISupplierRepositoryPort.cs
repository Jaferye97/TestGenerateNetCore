using Domain.Models.Supplier;

namespace Application.Ports.RepositoryEntityFrameworkSqlServer;

public interface ISupplierRepositoryPort
{
    //Task<bool> ExistRecordAsync(int id);
    Task<SupplierModel> AddSupplierAsync(SupplierModel model);
    Task<SupplierModel> UpdateSupplierAsync(SupplierModel model);
    Task<SupplierModel?> GetAsync(int id);
    Task<bool> ExistsSupplierByTaxIdAsync(string taxId);
    //Task<bool> UpdateAsync(SupplierModel model);
    //Task<PagedResult<SupplierModel>> GetAllAsync(SupplierFilterModel filter);
}
