using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Librabobus.Backend.Models.User;

namespace Librabobus.Backend.Repositories.Api
{
    public interface IUserRepository
    {
        Task<UserPageModel> GetUserPageAsync(Guid id);

        Task<List<UserSubModel>> GetSubscribersAsync(Guid id);
        
        Task<List<UserSubModel>> GetSubscriptionsAsync(Guid id);
        
        Task AddUserAsync(UserModel user);
        
        Task<List<UserModel>> GetUsersAsync();
        
        Task PatchUserAsync(Guid id, PatchUserModel patchUserModel);
    }
}