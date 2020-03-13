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
    public class CreateInvoiceCommand : InvoiceDTO, ICommandBase<InvoiceDTO>
    {
    }

    public class InvoiceCreateCommandHandler : CreateCommandHandlerBase<
        CreateInvoiceCommand,
        ResultResponse<InvoiceDTO>,
        Invoice,
        InvoiceDTO>
    {
        public InvoiceCreateCommandHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork.Invoice)
        {
        }
    }
}
