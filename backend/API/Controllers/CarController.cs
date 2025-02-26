using API.DTOs;
using AutoMapper;
using Core.Constants;
using Core.Entities;
using Core.Interfases;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace API.Controllers;
[ApiController]
[Route("api/cars")] // Usamos el plural en la ruta para seguir la convención RESTful
public class CarController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CarController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Car>>> Get()
    {
        var cars = await _unitOfWork.Cars.GetAllAsync();
        return _mapper.Map<List<Car>>(cars);
    }

    [HttpGet("price")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CarWithPrice>>> GetAllCarsWithPrice()   // Precio de cada coche
    {
        var cars = await _unitOfWork.Cars.GetAllAsync();

        // Hacer el Join y devolver instancias de CarWithPrice
        var availableCarsWithPrices = cars
            .Join(
                _unitOfWork.Prices.GetAllAsync().Result,  // Colección Price
                car => car.IdPrice,                       // Clave de la entidad Car
                price => price.Id,                        // Clave de la entidad Price
                (car, price) => new CarWithPrice          // Crear instancia de CarWithPrice
                {
                    Car = car,                           // Asignar Car
                    Price = price                        // Asignar Price
                })
            .ToList();  // Convertir a lista explícita

        return availableCarsWithPrices;  // No es necesario usar AutoMapper aquí
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Car>> Get(int id)
    {
        var car = await _unitOfWork.Cars.GetByIdAsync(id);
        if (car == null)
            return NotFound();

        return _mapper.Map<Car>(car);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Car>> Post(Car oCar)
    {
        var msg = string.Empty;
        try
        {
            var car = _mapper.Map<Car>(oCar);
            _unitOfWork.Cars.Add(car);
            await _unitOfWork.SaveAsync();
            if (car == null)
            {
                return BadRequest();
            }
            oCar.Id = car.Id;
            msg = string.Format(Constants.MSG_CAR_ADDED_SUCCESS, oCar.Model, oCar.Year);
            Log.Logger.Information(msg);
            return CreatedAtAction(nameof(Post), new { id = oCar.Id }, oCar);
        }
        catch (Exception exception)
        {
            msg = Constants.MSG_CAR_ADDED_ERROR;
            Log.Logger.Error(msg, exception);
            return BadRequest(msg);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Car>> Put([FromBody] Car oCar)
    {
        var msg = string.Empty;
        try
        {
            if (oCar == null)
                return NotFound();

            var car = _mapper.Map<Car>(oCar);
            _unitOfWork.Cars.Update(car);
            await _unitOfWork.SaveAsync();
            msg = string.Format(Constants.MSG_CAR_UPDATED_SUCCESS, oCar.Model, oCar.Year);
            Log.Information(msg);
            return oCar;
        }
        catch (Exception exception)
        {
            msg = Constants.MSG_CAR_UPDATED_ERROR;
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
            var car = await _unitOfWork.Cars.GetByIdAsync(id);
            if (car == null)
                return NotFound();

            _unitOfWork.Cars.Remove(car);
            await _unitOfWork.SaveAsync();
            msg = string.Format(Constants.MSG_CAR_DELETED_SUCCESS, car.Model, car.Year);
            Log.Information(msg);
            return NoContent();
        }
        catch (Exception exception)
        {
            msg = Constants.MSG_CAR_DELETED_ERROR;
            Log.Logger.Error(msg, exception);
            return BadRequest(msg);
        }
    }

    [HttpPatch("{id}/rented")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateRented(int id, [FromBody] UpdateCarRentedDTO rentedDTO)
    {
        var msg = string.Empty;

        try
        {
            if (rentedDTO == null)
            {
                return BadRequest("Datos Invalidos.");
            }

            var car = await _unitOfWork.Cars.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound(); 
            }

            car.Rented = rentedDTO.Rented;

            _unitOfWork.Cars.Update(car);
            await _unitOfWork.SaveAsync();

            msg = string.Format("Se ha actualizado el estado «Alquilado» del coche {0}..", car.Model);
            Log.Information(msg);

            return Ok(car);  // Retorna el objeto actualizado
        }
        catch (Exception exception)
        {
            msg = "Error al actualizar el estado 'Alquilado' del coche.";
            Log.Logger.Error(msg, exception);
            return BadRequest(msg);
        }
    }
}