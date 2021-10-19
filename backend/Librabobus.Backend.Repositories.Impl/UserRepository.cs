using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Librabobus.Backend.Models.Subject;
using Librabobus.Backend.Models.User;
using Librabobus.Backend.Repositories.Api;
using Librabobus.Database;
using Microsoft.EntityFrameworkCore;

namespace Librabobus.Backend.Repositories.Impl
{
    public class UserRepository: IUserRepository
    {
        readonly private LibrabobusDbContext _context;

        public UserRepository(LibrabobusDbContext context)
        {
            _context = context;
        }

        public async Task<UserPageModel> GetUserPageAsync(Guid id)
        {
            var user = await _context.User!
                .Where(u => u.Id == id)
                .Include(u => u.Subjects)
                .Include(u => u.Subscribers)
                .Include(u => u.Subscriptions)
                .FirstOrDefaultAsync();
            
            List<SubjectPreviewModel> subjects = user.Subjects!.Select(sub => new SubjectPreviewModel(id: sub.Id, name: sub.Name, photoBase64: sub.PhotoBase64!)).ToList();
            
            return new UserPageModel(
                id: user.Id,
                about: user.About!,
                countSubscribers: user.Subscribers!.Count,
                countSubscriptions: user.Subscriptions!.Count,
                name: user.Name,
                login: user.Login,
                photoBase64: user.PhotoBase64!,
                subjects: subjects
            );
        }
    }
}