using Application.UseCases.Supplier;
using Domain.Models.Supplier;
using WebApi.Extensions;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplierController
(
    IGetSupplierByIdUseCase getSupplierByIdUseCase,
    IAddSupplierUseCase addSupplierUseCase
) :
    ControllerBase
{
    private readonly IAddSupplierUseCase _addSupplierUseCase = addSupplierUseCase;
    private readonly IGetSupplierByIdUseCase _getSupplierByIdUseCase = getSupplierByIdUseCase;
    //private readonly IUpdateSupplierUseCase _updateSupplierUseCase;
    //private readonly IGetSupplierByFiltersUseCase _getSupplierByFiltersUseCase;

    //public SupplierController(
    //    IAddSupplierUseCase addSupplierUseCase,
    //    IGetSupplierByIdUseCase getSupplierByIdUseCase,
    //    IUpdateSupplierUseCase updateSupplierUseCase,
    //    IGetSupplierByFiltersUseCase getSupplierByFiltersUseCase
    //)
    //{
    //    _addSupplierUseCase = addSupplierUseCase;
    //    _getSupplierByIdUseCase = getSupplierByIdUseCase;
    //    _updateSupplierUseCase = updateSupplierUseCase;
    //    _getSupplierByFiltersUseCase = getSupplierByFiltersUseCase;
    //}

    [HttpPost()]
    public async Task<IActionResult> AddAsync([FromBody] SupplierModel model)
    {
        var result = await _addSupplierUseCase.ExecuteAsync(model);
        return result.ToActionResult(this);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] int id)
    {
        var result = await _getSupplierByIdUseCase.ExecuteAsync(id);

        return result.ToActionResult(this);
    }

    //[HttpPut()]
    //public async Task<IActionResult> UpdateAsync([FromBody] SupplierModel model)
    //{
    //    var result = await _updateSupplierUseCase.ExecuteAsync(model);

    //    return result == false ? NotFound() : Ok();
    //}

    //[HttpGet("GetAll")]
    //public async Task<IActionResult> GetAllAsync([FromQuery] SupplierFilterModel filters)
    //{
    //    var result = await _getSupplierByFiltersUseCase.ExecuteAsync(filters);

    //    return Ok(result);
    //}
}
