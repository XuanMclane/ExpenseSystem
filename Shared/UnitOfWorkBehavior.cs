using ExpenseSystem.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseSystem.Shared
{
    public class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse : IResponse
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _unitOfWork.Begin(IsolationLevel.ReadCommitted);
            var result = await next();
            if (result is IResponse r && r.IsSuccess)
            {
                await _unitOfWork.Commit();
            }
            return result;
        }
    }
}
