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
        private readonly IMaps<User, UserDTO> _userMap;


        public UserService(IMaps<User, UserDTO> userMap, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _userMap = userMap;
        }

        public async Task<ICollection<UserDTO>> GetAllUsersAsync(int pageNr, int pageSize, string sortBy)
        {
            var users = await _userRepository.GetAllUsersAsync(pageNr, pageSize, sortBy);
            var dTO = users.Select(_userMap.MapToDTO).ToList();

            return dTO;
        }

        public async Task<UserDTO?> GetUserByIdAsync(Guid id)
        {


            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
                return null;

            return _userMap.MapToDTO(user);


        }

        public async Task<UserDTO?> CreateUserAsync(UserDTO dTO)
        {

            var user = _userMap.MapToModel(dTO);
            user.Id = new Guid();
            var res = await _userRepository.CreateUserAsync(user);
            if (res == null)
                return null;

            return _userMap.MapToDTO(res);
        }

        
        public async Task<UserDTO?> UpdateUserAsync(Guid id, UserDTO dTO)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
                return null;

            var userUpdated = _userMap.MapToModel(dTO);
            userUpdated.Id = new Guid();
            var res = await _userRepository.UpdateUserAsync(id, userUpdated);
            return res != null ? _userMap.MapToDTO(userUpdated) : null;

        }

       
        public async Task<UserDTO?> DeleteUserAsync(Guid id)
        {
           
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
                return null;

            await _userRepository.DeleteUserAsync(id);
            return _userMap.MapToDTO(user);


        }

    }
}