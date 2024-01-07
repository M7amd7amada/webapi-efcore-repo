using Domain.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class FormsController : ApiController
{
    public FormsController(IUnitOfWork unitOfWork)
        : base(unitOfWork) { }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
    {
        return Ok(await _unitOfWork.Forms.GetAllAsync(
            page,
            pageSize,
            entity => entity.FormId,
            false));
    }
}