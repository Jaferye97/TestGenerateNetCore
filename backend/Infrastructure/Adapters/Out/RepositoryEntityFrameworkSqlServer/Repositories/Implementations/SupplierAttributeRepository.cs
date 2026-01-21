
using Application.Ports.RepositoryEntityFrameworkSqlServer;
using Domain.Models.Supplier;

namespace RepositoryEntityFrameworkSqlServer.Repositories.Implementations;

//public class SupplierAttributeRepository : BaseRepository<SupplierAttributeEntity, SupplierAttributeModel, int>, ISupplierAttributeRepository, ISupplierAttributeRepositoryPort
public class SupplierAttributeRepository
    (
        EntityDbContext context
    ) :
        BaseRepository<SupplierAttributeEntity, SupplierAttributeModel, int>
            (context, entity => entity.ToDomain(), entity => entity.ToEntity())
        , ISupplierAttributeRepositoryPort
{
    public async Task<IEnumerable<SupplierAttributeModel>> AddSupplierAttributeAsync(IEnumerable<SupplierAttributeModel> models)
    {
        var entities = await base.AddAsync(models);

        await _context.SaveChangesAsync();

        return entities.Select(SupplierAttributeMapper.ToDomain).ToList();
    }

    public async Task UpdateSupplierAttributeAsync(IEnumerable<SupplierAttributeModel> models)
    {
        await base.UpdateAsync(models);

        await _context.SaveChangesAsync();

        return;
    }
}
