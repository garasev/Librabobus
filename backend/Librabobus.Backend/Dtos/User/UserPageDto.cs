using System;
using System.Collections.Generic;
using Librabobus.Backend.Dtos.Subject;

namespace Librabobus.Backend.Dtos.User
{
    public class UserPageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? About { get; set; }
        public string? PhotoBase64 { get; set; }
        public string Login { get; set; }

        public int CountSubscribers { get; set; }
        public int CountSubscriptions { get; set; }

        public List<SubjectPreviewDto> Subjects { get; set; }

        public UserPageDto(Guid id,
            string name,
            string about,
            string photoBase64,
            string login,
            int countSubscribers,
            int countSubscriptions,
            List<SubjectPreviewDto> subjects)
        {
            Id = id;
            Name = name;
            About = about;
            PhotoBase64 = photoBase64;
            Login = login;
            CountSubscribers = countSubscribers;
            CountSubscriptions = countSubscriptions;
            Subjects = subjects;
        }
    }
}