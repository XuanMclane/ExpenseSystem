using ExpenseSystem.CQRS;
using ExpenseSystem.DTO;
using ExpenseSystem.Service.InvoiceService;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseSystem.Controllers
{
    public class InvoiceController : BaseController
    {
        public InvoiceController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}", Name = "GetInvoiceDetail")]
        public async Task<IActionResult> GetInvoiceDetail([FromRoute] long id)
        {
            var response = await _mediator.Send(new InvoiceDetailQuery { Id = id });
            if (response.IsSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.ErrorMessage);
        }

        [HttpPost(Name = "CreateInvoice")]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceCommand command)
        {
            var response = await _mediator.Send<ResultResponse<InvoiceDTO>>(command);
            if (response.IsSuccess)
            {
                return CreatedAtAction(nameof(GetInvoiceDetail), new { id = response.Result.Id }, response.Result);
            }
            return BadRequest(response.ErrorMessage);
        }

        [HttpPut("{id}", Name = "UpdateInvoice")]
        public async Task<IActionResult> UpdateInvoice([FromRoute] long id, [FromBody] UpdateInvoiceCommand command)
        {
            command.Id = id;
            var response = await _mediator.Send<ResultResponse<InvoiceDTO>>(command);
            if (response.IsSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.ErrorMessage);
        }
    }
}
