using Application.Ports.Persistence;
using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Supplier;

namespace Application.UseCases.Supplier.Implementations;

public class UpdateSupplierUseCase
(
    IUnitOfWork unitOfWork,
    ISupplierRepositoryPort repository,
    ISupplierAttributeRepositoryPort supplierAttributeRepository
) :
    IUpdateSupplierUseCase
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ISupplierRepositoryPort _repository = repository;
    private readonly ISupplierAttributeRepositoryPort _supplierAttributeRepository = supplierAttributeRepository;

    public async Task<bool> ExecuteAsync(SupplierModel model)
    {
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            var oldsRecords = model.SupplierAttribute?
                                        .Where(item => item.Id != 0)
                                        .ToList();

            var newsRecords = model.SupplierAttribute?
                                    .Where(item => item.Id == 0)
                                    .Select(x =>
                                    {
                                        x.SupplierId = model.Id;
                                        return x;
                                    })
                                    .ToList();

            model.SupplierAttribute = null;

            await _repository.UpdateSupplierAsync(model);

            if (newsRecords?.Count > 0)
            {
                await _supplierAttributeRepository.AddSupplierAttributeAsync(newsRecords);
            }

            if (oldsRecords?.Count > 0)
            {
                await _supplierAttributeRepository.UpdateSupplierAttributeAsync(oldsRecords);
            }

            await _unitOfWork.CommitAsync();

            return true;
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }
}

