using AutoMapper;
using Entity;
using ExpenseSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.Service.ExpenseTypeService
{
    public class ExpenseTypeMapperProfile : Profile
    {
        public ExpenseTypeMapperProfile()
        {
            CreateMap<ExpenseType, ExpenseTypeDTO>()
                .ReverseMap();
        }
    }
}
