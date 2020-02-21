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
    public class ExpenseTypeDetailQuery : QueryBase<ExpenseTypeDTO>
    {
    }

    public class ExpenseTypeDetailQueryHandler : FindQueryHandlerBase<
        ExpenseTypeDetailQuery,
        ResultResponse<ExpenseTypeDTO>,
        ExpenseType,
        ExpenseTypeDTO>
    {
        public ExpenseTypeDetailQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork.ExpenseType)
        {
        }
    }
}
