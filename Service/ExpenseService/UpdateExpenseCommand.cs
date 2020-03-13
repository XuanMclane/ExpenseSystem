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
    public class UpdateExpenseCommand : ExpenseDTO, ICommandBase<ExpenseDTO>
    {
    }

    public class UpdateExpenseCommandHandler : UpdateCommandHandlerBase<
        UpdateExpenseCommand,
        ResultResponse<ExpenseDTO>,
        Expense,
        ExpenseDTO>
    {
        public UpdateExpenseCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork.Expense)
        {
        }
    }
}
