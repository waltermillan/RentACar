using API.DTOs;
using Core.Entities;
using Core.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class UserDTOService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRolRepository _rolRepository;

        public UserDTOService(IUserRepository userRepository,
                                  IRolRepository rolRepository)
        {
            _userRepository = userRepository;
            _rolRepository = rolRepository;
        }

        public async Task<UserDTO> GetUserByIdc(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var rol = await _rolRepository.GetByIdAsync(user.IdRol);

            if (user is null || rol is null)
                return null;

            var userDTO = new UserDTO
            {
                Id = user.Id,
                UserName = user.Name,
                IdRol = user.IdRol,
                Rol = rol.Description
            };

            return userDTO;
        }

        public async Task <IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();

            if (users is null)
                return null;

            var usersDTO = new List<UserDTO>();

            foreach (var user in users)
                {
                    var rol = await _rolRepository.GetByIdAsync(user.IdRol);

                    var userDTO = new UserDTO
                    {
                        Id = user.Id,
                        UserName = user.Name,
                        IdRol = user.IdRol,
                        Rol = rol.Description
                    };

                usersDTO.Add(userDTO);
                }

            return usersDTO;
        }
    }
}
