using System;
using System.Threading.Tasks;
using Librabobus.Backend.Models.User;

namespace Librabobus.Backend.Repositories.Api
{
    public interface IUserRepository
    {
        Task<UserPageModel> GetUserPageAsync(Guid id);
    }
}