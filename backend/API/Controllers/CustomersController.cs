﻿using API.Services;
using AutoMapper;
using Core.Constants;
using Core.Entities;
using Core.Interfases;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace API.Controllers;

public class CustomersController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CustomersController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Customer>>> Get()
    {
        var customers = await _unitOfWork.Customers.GetAllAsync();
        return _mapper.Map<List<Customer>>(customers);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Customer>> Get(int id)
    {
        var customer = await _unitOfWork.Customers.GetByIdAsync(id);
        if (customer is null)
            return NotFound();

        return _mapper.Map<Customer>(customer);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Customer>> Post(Customer oCustomer)
    {
        var msg = string.Empty;
        try
        {
            var customer = _mapper.Map<Customer>(oCustomer);
            _unitOfWork.Customers.Add(customer);
            await _unitOfWork.SaveAsync();

            if (customer is null)
                return BadRequest();

            oCustomer.Id = customer.Id;

            msg = string.Format(Constants.MSG_CUSTOMER_ADDED_SUCCESS, customer.Name, customer.Document);
            Log.Logger.Information(msg);

            return CreatedAtAction(nameof(Post), new { id = oCustomer.Id }, oCustomer);
        }
        catch (Exception exception)
        {
            msg = Constants.MSG_CUSTOMER_ADDED_ERROR;
            Log.Logger.Error(msg, exception);
            return BadRequest(msg);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Customer>> Put([FromBody] Customer oCustomer)
    {
        var msg = string.Empty;
        try
        {
            if (oCustomer is null)
                return NotFound();

            var customer = _mapper.Map<Customer>(oCustomer);
            _unitOfWork.Customers.Update(customer);
            await _unitOfWork.SaveAsync();

            msg = string.Format(Constants.MSG_CUSTOMER_UPDATED_SUCCESS, customer.Name, customer.Document);
            Log.Logger.Information(msg);

            return oCustomer;
        }
        catch (Exception exception)
        {
            msg = Constants.MSG_CUSTOMER_UPDATED_ERROR;
            Log.Logger.Error(msg, exception);
            return BadRequest(msg);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var msg = string.Empty;
        try
        {
            var customer = await _unitOfWork.Customers.GetByIdAsync(id);

            if (customer is null)
                return NotFound();

            _unitOfWork.Customers.Remove(customer);
            await _unitOfWork.SaveAsync();

            msg = string.Format(Constants.MSG_CUSTOMER_DELETED_SUCCESS, customer.Name, customer.Document);
            Log.Logger.Information(msg);
            return NoContent();
        }
        catch (Exception exception)
        {
            msg = Constants.MSG_CUSTOMER_DELETED_ERROR;
            Log.Logger.Error(msg, exception);
            return BadRequest(msg);
        }
    }
}