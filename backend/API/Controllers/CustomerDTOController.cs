using AutoMapper;
using Core.Constants;
using Core.Entities;
using Core.Interfases;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace API.Controllers;

[ApiController]
[Route("api/customers")] // Usamos el plural en la ruta para seguir la convención RESTful
public class CustomerDTOController : ControllerBase
{
    private readonly CustomerDTOService _customerDTOService;

    public CustomerDTOController(CustomerDTOService customerDTOService)
    {
        _customerDTOService = customerDTOService;
    }

    [HttpGet("view")]
    public async Task<IActionResult> GetCustomerDTO(int customerId, int carId, int rentId, int payTypeId, int priceId)
    {
        var customerDTO = await _customerDTOService.GetCustomerDTOAsync(customerId, carId, rentId, payTypeId, priceId);

        if (customerDTO == null)
        {
            return NotFound(); // o algún otro manejo de error
        }

        return Ok(customerDTO);
    }
}