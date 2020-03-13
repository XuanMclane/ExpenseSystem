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
    public class UpdateInvoiceCommand : InvoiceDTO, ICommandBase<InvoiceDTO>
    {
    }

    public class UpdateInvoiceCommandHandler : UpdateCommandHandlerBase<
        UpdateInvoiceCommand,
        ResultResponse<InvoiceDTO>,
        Invoice,
        InvoiceDTO>
    {
        public UpdateInvoiceCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork.Invoice)
        {
        }
    }
}
