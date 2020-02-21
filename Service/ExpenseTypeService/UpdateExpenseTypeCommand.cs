using AutoMapper;
using Entity;
using ExpenseSystem.CQRS;
using ExpenseSystem.DTO;
using ExpenseSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.Service.ExpenseTypeService
{
    public class UpdateExpenseTypeCommand : ExpenseTypeDTO, ICommandBase<ExpenseTypeDTO>
    {
    }

    public class UpdateExpenseTypeCommandHandler : UpdateCommandHandlerBase<
        UpdateExpenseTypeCommand,
        ResultResponse<ExpenseTypeDTO>,
        ExpenseType,
        ExpenseTypeDTO>
    {
        public UpdateExpenseTypeCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork.ExpenseType)
        {
        }
    }
}
