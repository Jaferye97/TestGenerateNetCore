using Domain.Models.Supplier;

namespace Application.UseCases.Supplier
{
    public interface IAddSupplierUseCase
    {
        Task<Result<SupplierModel>> ExecuteAsync(SupplierModel model);
    }
}
