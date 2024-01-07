using AutoMapper;

using DataAccess.Data;

using Domain.DTOs.RequestDTOs;
using Domain.DTOs.ResponseDTOs;
using Domain.Interfaces;
using Domain.Models;
using Domain.Settings;

using Microsoft.Extensions.Options;

namespace DataAccess.Repositories;

public class FormRepository : RepositoryBase<Form, FormRequestDto, FormResponseDto>, IFormRepository
{
    public FormRepository(AppDbContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        : base(context, mapper, appSettings) { }
}