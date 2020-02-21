using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.CQRS
{
    public class QueryBase<TViewModel> : IRequest<ResultResponse<TViewModel>>
    {
        public long Id { get; set; }
    }
}
