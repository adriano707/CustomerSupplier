using CustomerSupplier.Domain.Entities;
using CustomerSupplier.Domain.Sesrvices;
using CustomerSupplier.WebApi.Dto;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSupplier.WebApi.Controllers;

[Authorize("Bearer")]
[ApiController]
[Route("customer-suppliers")]
public class CustomerSupplierController : ControllerBase
{
    private readonly ICustomerSupplierService _customerSupplierService;
    private readonly IValidator<CustomerSupplierDto> _validator;

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetCustomerSupplier([FromRoute] int id)
    {
        var customerSupplier = await _customerSupplierService.GetCustomerSupplierById(id);
        return Ok(customerSupplier);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomerSupplier()
    {
        var customerSuppliers = await _customerSupplierService.GetAllCustomerSupplier();
        return Ok(customerSuppliers);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomerSupplier([FromBody] CustomerSupplierDto dto)
    {
        var validateResult = _validator.Validate(dto);

        if (validateResult.IsValid)
        {
            var addresses = dto.Addresses.Select(a => (a.Road, a.District, a.City, a.State)).ToList();
            var contacts = dto.Contacts.Select(c => (c.Email, c.Phone)).ToList();

            try
            {
                await _customerSupplierService.CreateCustomerSupplier(dto.Name, contacts, addresses);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        return Conflict(validateResult.Errors);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateCustomerSupplier([FromRoute] int id, [FromBody] CustomerSupplierDto dto)
    {
        var validateResult = _validator.Validate(dto);

        if (validateResult.IsValid)
        {
            var addresses = dto.Addresses.Select(a => (a.Id, a.Road, a.District, a.City, a.State)).ToList();
            var contacts = dto.Contacts.Select(c => (c.Id, c.Email, c.Phone)).ToList();

            try
            {
                await _customerSupplierService.UpdateCustomerSupplier(id, dto.Name, contacts, addresses);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        return BadRequest(validateResult.Errors); ;
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteCustomerSupplier([FromRoute] int id)
    {
        await _customerSupplierService.DeleteCustomerSupplier(id);
        return Ok();
    }
}