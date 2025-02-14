using AutoMapper;
using Core.Constants;
using Core.Entities;
using Core.Interfases;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace API.Controllers;

public class RentController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RentController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // Método existente: obtener todas las ciudades
    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Rent>>> Get()
    {
        var rents = await _unitOfWork.Rents.GetAllAsync();
        return _mapper.Map<List<Rent>>(rents);
    }

    // Método existente: obtener una ciudad por su ID
    [HttpGet("Get")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Rent>> Get(int id)
    {
        var rent = await _unitOfWork.Rents.GetByIdAsync(id);
        if (rent == null)
            return NotFound();

        return _mapper.Map<Rent>(rent);
    }

    // Método existente: agregar una ciudad
    [HttpPost("Add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Rent>> Post(Rent oRent)
    {
        var msg = string.Empty;
        try
        {
            var rent = _mapper.Map<Rent>(oRent);
            _unitOfWork.Rents.Add(rent);
            await _unitOfWork.SaveAsync();
            if (rent == null)
            {
                return BadRequest();
            }
            oRent.Id = rent.Id;

            object[] obj = new object[] { rent.IdCustomer, rent.IdCar, rent.Day, rent.DayRemaining, rent.PayTypeId, rent.PriceId };
            msg = string.Format(Constants.MSG_RENT_ADDED_SUCCESS, obj);
            Log.Logger.Information(msg);

            return CreatedAtAction(nameof(Post), new { id = oRent.Id }, oRent);
        }
        catch (Exception exception)
        {
            msg = Constants.MSG_RENT_ADDED_ERROR;
            Log.Logger.Error(msg, exception);
            return BadRequest(msg);
        }
    }

    // Método existente: actualizar una ciudad
    [HttpPut("Update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Rent>> Put([FromBody] Rent oRent)
    {
        var msg = string.Empty;
        try
        {
            if (oRent == null)
                return NotFound();

            var rent = _mapper.Map<Rent>(oRent);
            _unitOfWork.Rents.Update(rent);
            await _unitOfWork.SaveAsync();

            object[] obj = new object[] { rent.IdCustomer, rent.IdCar, rent.Day, rent.DayRemaining, rent.PayTypeId, rent.PriceId };
            msg = string.Format(Constants.MSG_RENT_UPDATED_SUCCESS, obj);
            Log.Logger.Information(msg);

            return oRent;
        }
        catch (Exception exception)
        {
            msg = Constants.MSG_RENT_UPDATED_ERROR;
            Log.Logger.Error(msg, exception);
            return BadRequest(msg);
        }
    }

    // Método existente: eliminar una ciudad
    [HttpDelete("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var msg = string.Empty;
        try
        {
            var rent = await _unitOfWork.Rents.GetByIdAsync(id);
            if (rent == null)
                return NotFound();

            _unitOfWork.Rents.Remove(rent);
            await _unitOfWork.SaveAsync();

            object[] obj = new object[] { rent.IdCustomer, rent.IdCar, rent.Day, rent.DayRemaining, rent.PayTypeId, rent.PriceId };
            msg = string.Format(Constants.MSG_RENT_DELETED_SUCCESS, obj);
            Log.Logger.Information(msg);

            return NoContent();
        }
        catch (Exception exception)
        {
            msg = Constants.MSGF_RENT_DELETED_ERROR;
            Log.Logger.Error(msg, exception);
            return BadRequest(msg);
        }
    }
}