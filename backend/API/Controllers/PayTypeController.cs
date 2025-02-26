using AutoMapper;
using Core.Constants;
using Core.Entities;
using Core.Interfases;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace API.Controllers;
[ApiController]
[Route("api/paytypes")] // Usamos el plural en la ruta para seguir la convención RESTful
public class PayTypeController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PayTypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PayType>>> Get()
    {
        var payType = await _unitOfWork.PaysType.GetAllAsync();
        return _mapper.Map<List<PayType>>(payType);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PayType>> Get(int id)
    {
        var payType = await _unitOfWork.PaysType.GetByIdAsync(id);
        if (payType == null)
            return NotFound();

        return _mapper.Map<PayType>(payType);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PayType>> Post(PayType oPayType)
    {
        var msg = string.Empty;
        try
        {
            var payType = _mapper.Map<PayType>(oPayType);
            _unitOfWork.PaysType.Add(payType);
            await _unitOfWork.SaveAsync();
            if (payType == null)
            {
                return BadRequest();
            }
            oPayType.Id = payType.Id;

            msg = string.Format(Constants.MSG_PAYTYPE_ADDED_SUCCESS, oPayType.Name);
            Log.Logger.Information(msg);

            return CreatedAtAction(nameof(Post), new { id = oPayType.Id }, oPayType);
        }
        catch (Exception exception)
        {
            msg = Constants.MSG_PAYTYPE_ADDED_ERROR;
            Log.Logger.Error(msg, exception);
            return BadRequest(msg);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PayType>> Put([FromBody] PayType oPayType)
    {
        var msg = string.Empty;
        try
        {
            if (oPayType == null)
                return NotFound();

            var payType = _mapper.Map<PayType>(oPayType);
            _unitOfWork.PaysType.Update(payType);
            await _unitOfWork.SaveAsync();

            msg = string.Format(Constants.MSG_PAYTYPE_UPDATED_SUCCESS, oPayType.Name);
            Log.Logger.Information(msg);

            return oPayType;
        }
        catch (Exception exception)
        {
            msg = Constants.MSG_PAYTYPE_UPDATED_ERROR;
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
            var payType = await _unitOfWork.PaysType.GetByIdAsync(id);
            if (payType == null)
                return NotFound();

            _unitOfWork.PaysType.Remove(payType);
            await _unitOfWork.SaveAsync();

            msg = string.Format(Constants.MSG_PAYTYPE_DELETED_SUCCESS, payType.Name);
            Log.Logger.Information(msg);

            return NoContent();
        }
        catch (Exception exception)
        {
            msg = Constants.MSG_PAYTYPE_DELETED_ERROR;
            Log.Logger.Error(msg, exception);
            return BadRequest(msg);
        }
    }
}