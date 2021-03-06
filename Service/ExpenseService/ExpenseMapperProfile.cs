﻿using AutoMapper;
using Entity;
using ExpenseSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.Service.ExpenseService
{
    public class InvoiceMapperProfile : Profile
    {
        public InvoiceMapperProfile()
        {
            CreateMap<Expense, ExpenseDTO>()
                .ForMember(d => d.ExpenseType, o => o.Ignore());

            CreateMap<ExpenseDTO, Expense>()
                .ForMember(d => d.ExpenseType, o => o.Ignore());
        }
    }
}
