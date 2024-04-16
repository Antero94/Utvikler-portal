using Utvikler_portal.JobSeekerModul.Maps.Interfaces;
using Utvikler_portal.JobSeekerModul.Models.Entities;
using Utvikler_portal.JobSeekerModul.Models.DTOs;
using Utvikler_portal.JobSeekerModul.Repositories.Interfaces;
using Utvikler_portal.JobSeekerModul.Services.Interfaces;


namespace Utvikler_portal.JobSeekerModul.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMaps<User, UserRegDTO> _userRegMap;


        public UserService(IUserRepository userRepository, IMaps<User, UserRegDTO> userRegMap)
        {
            _userRepository = userRepository;
            _userRegMap = userRegMap;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var userDtos = new List<UserDTO>();

            foreach (var user in users)
            {
                userDtos.Add(_userRegMap.MapToDTO(user));
            }
            return userDtos;
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {


            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            return _userRegMap.MapToDTO(user);


        }

        public async Task<UserDTO> CreateUserAsync(UserRegDTO userRegDto)
        {

            var user = _userRegMap.MapToModel(userRegDto);
            var createdUser = await _userRepository.AddAsync(user);
            return _userRegMap.MapToDTO(createdUser);
        }

        
        public async Task UpdateUserAsync(UserDTO userDto)
        {
            var existingUser = await _userRepository.GetByIdAsync(userDto.Id);
            if (existingUser == null)
            {
               
                return;
            }

            existingUser.Id = userDto.Id;
            existingUser.FirstName = userDto.FirstName;
            existingUser.LastName = userDto.LastName;
            existingUser.Email = userDto.Email;
            existingUser.Updated = DateTime.Now;

            
            await _userRepository.UpdateAsync(existingUser);
        }

       
        public async Task DeleteUserAsync(Guid id)
        {
           
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                
                return;
            }
            
            await _userRepository.DeleteAsync(id);


        }

    }
}