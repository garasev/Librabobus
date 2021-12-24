using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Librabobus.Backend.Models.Subject;
using Librabobus.Backend.Models.User;
using Librabobus.Backend.Repositories.Api;
using Librabobus.Database;
using Librabobus.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Librabobus.Backend.Repositories.Impl
{
    public class UserRepository: IUserRepository
    {
        readonly private LibrabobusDbContext _context;
        private static Random random = new Random();

        public UserRepository(LibrabobusDbContext context)
        {
            _context = context;
        }
        
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
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

        public async Task<List<UserSubModel>> GetSubscribersAsync(Guid id)
        {
            var users = await _context.Subscription!
                .Where(s => s.UserToId == id)
                .Include(s => s.UserFrom)
                .ToListAsync();

            return users.Select(sub => new UserSubModel(id: sub.UserFrom!.Id,
                name: sub.UserFrom!.Name, photoBase64: sub.UserFrom!.PhotoBase64!)).ToList();
        }
        
        public async Task<List<UserSubModel>> GetSubscriptionsAsync(Guid id)
        {
            var users = await _context.Subscription!
                .Where(s => s.UserFromId == id)
                .Include(s => s.UserFrom)
                .ToListAsync();

            return users.Select(sub => new UserSubModel(id: sub.UserTo!.Id,
                name: sub.UserTo!.Name, photoBase64: sub.UserFrom!.PhotoBase64!)).ToList();
        }

        public async Task AddUserAsync(UserModel user)
        {
            var salt = RandomString(8);
            var userDb = new User(
                id: user.Id,
                name: user.Name,
                about: user.About,
                photoBase64: user.PhotoBase64,
                login: user.Login,
                salt: salt,
                hash: salt + user.Password
            );
            await _context.User!.AddAsync(userDb);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            var users =  await _context.User!.ToListAsync();
            return users.Select(user => new UserModel(
                id: user.Id,
                name: user.Name,
                about: user.About!,
                photoBase64: user.PhotoBase64!,
                login: user.Login,
                password: user.Hash)).ToList();
        }
        
        public async Task PatchUserAsync(Guid id, PatchUserModel patchUserModel)
        {
            var user = await _context.User!
                .SingleAsync(x => x.Id == id);
            Console.WriteLine(patchUserModel.Name);

            if (patchUserModel.Name is not null)
                user.Name = patchUserModel.Name;
            if (patchUserModel.About is not null)
                user.About = patchUserModel.About;
            if (patchUserModel.PhotoBase64 is not null)
                user.PhotoBase64 = patchUserModel.PhotoBase64;
            if (patchUserModel.Login is not null)
                user.Login = patchUserModel.Login;
            if (patchUserModel.Password is not null)
                user.Hash = user.Salt + patchUserModel.Password;
	
            await _context.SaveChangesAsync();
        }
        
        public async Task<UserModel?> Login(string login, string password)
        {
            var account = await _context.User!
                .Where(c => c.Login == login)
                .FirstOrDefaultAsync();

            if (account == null)
            {
                throw new Exception($"Account with Login: {login} not found.");
            }

            return account.Hash != account.Salt + password ? null : new UserModel(
                id: account.Id,
                name: account.Name,
                about: account.About!,
                photoBase64: account.PhotoBase64!,
                login: account.Login,
                password: password);
        }

    }
}