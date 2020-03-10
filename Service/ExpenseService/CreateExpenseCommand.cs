using AutoMapper;
using Entity;
using ExpenseSystem.CQRS;
using ExpenseSystem.DTO;
using ExpenseSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.Service.ExpenseService
{
    public class CreateExpenseCommand : ExpenseDTO, ICommandBase<ExpenseDTO>
    {
    }

    public class ExpenseCreateCommandHandler : CreateCommandHandlerBase<
        CreateExpenseCommand,
        ResultResponse<ExpenseDTO>,
        Expense,
        ExpenseDTO>
    {
        public ExpenseCreateCommandHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork) : base(mapper, unitOfWork.Expense)
        {
        }
    }
}
