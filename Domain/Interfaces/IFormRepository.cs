using Domain.DTOs.RequestDTOs;
using Domain.DTOs.ResponseDTOs;
using Domain.Models;

namespace Domain.Interfaces;

public interface IFormRepository : IRepositoryBase<Form, FormRequestDto, FormResponseDto>
{

}