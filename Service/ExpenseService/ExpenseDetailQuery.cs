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
    public class ExpenseDetailQuery : QueryBase<ExpenseDTO>
    {
    }

    public class ExpenseDetailQueryHandler : FindQueryHandlerBase<
        ExpenseDetailQuery,
        ResultResponse<ExpenseDTO>,
        Expense,
        ExpenseDTO>
    {
        public ExpenseDetailQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork.Expense)
        {
        }
    }
}
