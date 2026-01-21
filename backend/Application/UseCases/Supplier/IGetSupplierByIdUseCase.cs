using Domain.Models.Supplier;

namespace Application.UseCases.Supplier
{
    public interface IGetSupplierByIdUseCase
    {
        Task<Result<SupplierModel>> ExecuteAsync(int id);
    }
}
