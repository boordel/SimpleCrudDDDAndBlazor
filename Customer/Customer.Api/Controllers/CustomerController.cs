using Customer.Application.Commands;
using Customer.Application.Handlers;
using Customer.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customer.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<CustomerController>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Customer.Domain.Entities.CustomerAggregate.Customer>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<IEnumerable<Customer.Domain.Entities.CustomerAggregate.Customer>>> Get() 
    {
        try
        {
            var customers = await _mediator.Send(new GetCustomerListQuery());

            if (customers == null)
                return NotFound();
            else
                return Ok(customers);
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "No customer found: " + ex.Message);
        }
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Customer.Domain.Entities.CustomerAggregate.Customer), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<Customer.Domain.Entities.CustomerAggregate.Customer>> Get(int id)
    {
        try
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery(id));

            if (customer == null)
                return NotFound();
            else
                return Ok(customer);
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "No customer found: " + ex.Message);
        }
    }

    // POST api/<CustomerController>
    [HttpPost]
    [ProducesResponseType(typeof(Customer.Domain.Entities.CustomerAggregate.Customer), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Customer.Domain.Entities.CustomerAggregate.Customer>> Post([FromBody] Customer.Domain.Entities.CustomerAggregate.Customer model)
    {
        try
        {
            var customer = await _mediator.Send(new CreateCustomerCommand(
                model.FirstName,
                model.LastName,
                model.DateOfBirth,
                model.PhoneNumber,
                model.Email,
                model.BankAccountNumber
                ));

            if (customer == null)
                return BadRequest();
            else
                return Ok(customer);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error inserting customer: " + ex.Message);
        }
    }

    // PUT api/<CustomerController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Customer.Domain.Entities.CustomerAggregate.Customer), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<Customer.Domain.Entities.CustomerAggregate.Customer>> Put(int id, [FromBody] Customer.Domain.Entities.CustomerAggregate.Customer model)
    {
        try
        {
            var customer = await _mediator.Send(new UpdateCustomerByIdCommand(
                id,
                model.FirstName,
                model.LastName,
                model.DateOfBirth,
                model.PhoneNumber,
                model.Email,
                model.BankAccountNumber
                ));

            if (customer == null)
                return BadRequest();
            else
                return Ok(customer);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating customer: " + ex.Message);
        }
    }

    // DELETE api/<CustomerController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var result = await _mediator.Send(new DeleteCustomerByIdCommand(id));

            return result ? Ok() : NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "No customer found: " + ex.Message);
        }
    }
}
