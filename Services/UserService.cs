using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using BlazorPBM.Models;

namespace BlazorPBM.Services
{
    public class UserService
    {
        private readonly DatabaseService<User> _databaseService;
        private readonly TokenService _tokenService;

        public UserService(DatabaseService<User> databaseService, TokenService tokenService)
        {
            _databaseService = databaseService;
            _tokenService = tokenService;
        }

        private List<User>? userList;
        public async Task<List<User>> GetAllUser()
        {
            if (userList is null)
                userList = await _databaseService.LoadFromSheet("user");
            return userList;
        }

        public async Task<User> GetUser(int userId)
        {
            return (await GetAllUser()).First(x => x.UserId == userId);
        }

        public async Task SetUserId()
        {
            List<User> userList = await GetAllUser();
            if (_tokenService.UserInfo is not null)
                _tokenService.UserInfo.UserId = userList.First(x => x.Username == _tokenService.UserInfo.Email?.Split('@')[0]).UserId;
        }
    }
}
