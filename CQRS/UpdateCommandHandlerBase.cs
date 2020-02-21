using AutoMapper;
using Entity;
using ExpenseSystem.DTO;
using ExpenseSystem.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseSystem.CQRS
{
    public class UpdateCommandHandlerBase<TCommand, TResponse, TEntity, TViewModel> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommandBase<TViewModel>, IRequest<TResponse>
        where TResponse : ResultResponse<TViewModel>
        where TEntity : BaseEntity
        where TViewModel : BaseDTO
    {
        protected readonly IMapper _mapper;
        protected readonly IRepository<TEntity> Repository;

        public UpdateCommandHandlerBase(IMapper mapper, IRepository<TEntity> repository)
        {
            _mapper = mapper;
            Repository = repository;
        }

        public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var result = new ResultResponse<TViewModel> { IsSuccess = true };
            try
            {
                var entity = await Repository.Update(_mapper.Map<TEntity>(request));
                if (entity == null)
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = "Cannot find the record";
                    return (TResponse)result;
                }
                result.Result = _mapper.Map<TViewModel>(entity);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }
            return (TResponse)result;
        }
    }
}
