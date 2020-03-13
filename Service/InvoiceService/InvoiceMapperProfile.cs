using AutoMapper;
using Entity;
using ExpenseSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.Service.InvoiceService
{
    public class InvoiceMapperProfile : Profile
    {
        public InvoiceMapperProfile()
        {
            CreateMap<Invoice, InvoiceDTO>()
                .ReverseMap();
        }
    }
}
