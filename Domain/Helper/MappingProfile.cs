using AutoMapper;

using Domain.Data;
using Domain.DTOs.RequestDTOs;
using Domain.DTOs.ResponseDTOs;
using Domain.Models;

namespace Domain.Helper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // CreateMap<Dest, Source>();
        CreateMap<PagedResult<FormResponseDto>, PagedResult<Form>>();
        CreateMap<FormResponseDto, Form>();
        CreateMap<Form, FormRequestDto>();
        CreateMap<PagedResult<Form>, PagedResult<FormResponseDto>>();
    }

}