using Domain.Models.Supplier;

namespace Application.UseCases.Supplier.Implementations
{
    public class GetSupplierByIdUseCase
        (
            ISupplierRepositoryPort repository
        ) : 
            IGetSupplierByIdUseCase
    {
        private readonly ISupplierRepositoryPort _repository = repository;

        public async Task<Result<SupplierModel>> ExecuteAsync(int id)
        {
            var supplier = await _repository.GetAsync(id);

            Result<SupplierModel> result = supplier is null
                    ? Result<SupplierModel>.NotFound("Not Found Supplier")
                    : Result<SupplierModel>.Success(supplier);

            return result;
        }
    }
}
