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

        [HttpPost(Name = "CreateVendor")]
        public async Task<IActionResult> CreateVendor([FromBody] CreateExpenseTypeCommand command)
        {
            var response = await _mediator.Send<ResultResponse<ExpenseTypeDTO>>(command);
            if (response.IsSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.ErrorMessage);
        }
    }
}
