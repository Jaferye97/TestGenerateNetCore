using Application.Ports.Persistence;
using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Supplier;

namespace Application.UseCases.Supplier.Implementations;

public class AddSupplierUseCase
    (
        ISupplierRepositoryPort repository,
        IUnitOfWork unitOfWork
    ) : 
        IAddSupplierUseCase
{
    private readonly ISupplierRepositoryPort _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<SupplierModel>> ExecuteAsync(SupplierModel model)
    {
        if (string.IsNullOrWhiteSpace(model.TaxId))
            return Result<SupplierModel>.ValidationError("TaxId is required");

        if (await _repository.ExistsSupplierByTaxIdAsync(model.TaxId))
            return Result<SupplierModel>
                .BusinessError("Supplier with this TaxId already exists");

        await _unitOfWork.BeginTransactionAsync();

        try
        {
            var result = await _repository.AddSupplierAsync(model);

            await _unitOfWork.CommitAsync();

            return Result<SupplierModel>.Success(result, "Supplier created successfully");
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackAsync();

            return Result<SupplierModel>
                .SystemError($"Unexpected error: {ex.Message}");
        }
    }
}
