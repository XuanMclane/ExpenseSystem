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
    public class CreateCommandHandlerBase<TCommand, TResponse, TEntity, TViewModel> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommandBase<TViewModel>, IRequest<TResponse>
        where TResponse : ResultResponse<TViewModel>
        where TEntity : BaseEntity
        where TViewModel : BaseDTO
    {
        protected readonly IMapper _mapper;
        protected readonly IRepository<TEntity> Repository;

        protected CreateCommandHandlerBase(IMapper mapper, IRepository<TEntity> repository)
        {
            _mapper = mapper;
            Repository = repository;
        }

        public async Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var result = new ResultResponse<TViewModel> { IsSuccess = true };
            try
            {
                var entity = await Repository.Add(_mapper.Map<TEntity>(request));
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
