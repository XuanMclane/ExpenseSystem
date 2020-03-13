using AutoMapper;
using Entity;
using ExpenseSystem.CQRS;
using ExpenseSystem.DTO;
using ExpenseSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.Service.InvoiceService
{
    public class InvoiceDetailQuery : QueryBase<InvoiceDTO>
    {
    }

    public class InvoiceDetailQueryHandler : FindQueryHandlerBase<
        InvoiceDetailQuery,
        ResultResponse<InvoiceDTO>,
        Invoice,
        InvoiceDTO>
    {
        public InvoiceDetailQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork.Invoice)
        {
        }
    }
}
