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
    public class CreateExpenseTypeCommand : ExpenseTypeDTO, ICommandBase<ExpenseTypeDTO>
    {
    }

    public class ExpenseTypeCreateCommandHandler : CreateCommandHandlerBase<
        CreateExpenseTypeCommand,
        ResultResponse<ExpenseTypeDTO>,
        ExpenseType,
        ExpenseTypeDTO>
    {
        public ExpenseTypeCreateCommandHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork.ExpenseType)
        {
        }
    }
}
