using AutoMapper;
using Core.Entities;
using Core.Interfases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RolesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RolesController(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var roles = await _unitOfWork.Roles.GetAllAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error retrieving roles", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var role = await _unitOfWork.Roles.GetByIdAsync(id);

                if (role is null)
                    return NotFound(new { Message = "Role not found" });
                return Ok(role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error retrieving role", Details = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] Rol role)
        {
            try
            {
                if (role is null)
                    return BadRequest(new { Message = "Invalid role data" });

                _unitOfWork.Roles.Add(role);
                await _unitOfWork.SaveAsync();
                return CreatedAtAction(nameof(Get), new { id = role.Id }, role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error creating role", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(int id, [FromBody] Rol role)
        {
            try
            {
                if (role is null || id != role.Id)
                    return BadRequest(new { Message = "Invalid role data" });
                var existingRole = await _unitOfWork.Roles.GetByIdAsync(id);

                if (existingRole is null)
                    return NotFound(new { Message = "Role not found" });

                _unitOfWork.Roles.Update(role);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error updating role", Details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var role = await _unitOfWork.Roles.GetByIdAsync(id);

                if (role is null)
                    return NotFound(new { Message = "Role not found" });

                _unitOfWork.Roles.Remove(role);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error deleting role", Details = ex.Message });
            }
        }
    }
}
