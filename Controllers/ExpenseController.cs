using ExpenseSystem.CQRS;
using ExpenseSystem.DTO;
using ExpenseSystem.Service.ExpenseService;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.Controllers
{
    public class ExpenseController : BaseController
    {
        public ExpenseController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}", Name = "GetExpenseDetail")]
        public async Task<IActionResult> GetExpenseDetail([FromRoute] long id)
        {
            var response = await _mediator.Send(new ExpenseDetailQuery { Id = id });
            if (response.IsSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.ErrorMessage);
        }

        [HttpPost(Name = "CreateExpense")]
        public async Task<IActionResult> CreateExpense([FromBody] CreateExpenseCommand command)
        {
            var response = await _mediator.Send<ResultResponse<ExpenseDTO>>(command);
            if (response.IsSuccess)
            {
                return CreatedAtAction(nameof(GetExpenseDetail), new { id = response.Result.Id }, response.Result);
            }
            return BadRequest(response.ErrorMessage);
        }

        [HttpPut("{id}", Name = "UpdateExpense")]
        public async Task<IActionResult> UpdateExpense([FromRoute] long id, [FromBody] UpdateExpenseCommand command)
        {
            command.Id = id;
            var response = await _mediator.Send<ResultResponse<ExpenseDTO>>(command);
            if (response.IsSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.ErrorMessage);
        }
    }
}
