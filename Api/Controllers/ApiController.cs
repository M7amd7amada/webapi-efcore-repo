using Domain.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ApiController : ControllerBase
{
    protected readonly IUnitOfWork _unitOfWork;

    protected ApiController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}