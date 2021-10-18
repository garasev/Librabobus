using System;
using System.Collections.Generic;
#nullable enable

namespace Librabobus.Database.Models
{
    public class User
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string? About { get; set; }
        public string? PhotoBase64 { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        
        public ICollection<Subject>? Subjects { get; set; }
        public ICollection<SavedSubject>? SavedSubjects { get; set; }
        public ICollection<Subscription>? Subscriptions { get; set; }
        public User(Guid id,
            string name,
            string? about, 
            string? photoBase64,
            string hash,
            string salt)
        {
            Id = id;
            Name = name;
            About = about;
            PhotoBase64 = photoBase64;
            Hash = hash;
            Salt = salt;
        }
    }
}