using System;

namespace Librabobus.Backend.Dtos.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? About { get; set; }
        public string? PhotoBase64 { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public UserDto(Guid id,
            string name,
            string about,
            string photoBase64,
            string login, 
            string password)
        {
            Id = id;
            Name = name;
            About = about;
            PhotoBase64 = photoBase64;
            Login = login;
            Password = password;
        }
    }
}