using ExpenseSystem.CQRS;
using ExpenseSystem.DTO;
using ExpenseSystem.Service.ExpenseTypeService;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.Controllers
{
    public class ExpenseTypeController : BaseController
    {
        public ExpenseTypeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}", Name = "GetExpenseTypeDetail")]
        public async Task<IActionResult> GetExpenseDetail([FromRoute] long id)
        {
            var response = await _mediator.Send(new ExpenseTypeDetailQuery { Id = id });
            if (response.IsSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.ErrorMessage);
        }

        [HttpPost(Name = "CreateVendor")]
        public async Task<IActionResult> CreateVendor([FromBody] CreateExpenseTypeCommand command)
        {
            var response = await _mediator.Send<ResultResponse<ExpenseTypeDTO>>(command);
            if (response.IsSuccess)
            {
                return CreatedAtAction(nameof(GetExpenseDetail), new { id = response.Result.Id }, response.Result);
            }
            return BadRequest(response.ErrorMessage);
        }
    }
}
