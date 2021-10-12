using System;
using System.Collections.Generic;
#nullable enable

namespace Librabobus.Database.Models
{
    public class Subject
    {
        public Guid Id { get; }
        public Guid OwnerId { get; }
        public string Name { get; set }
        public bool Privat { get; set }
        public string? Description { get; set }
        public string? PhotoBase64 { get; set; }
        public ICollection<Record>? Records { get; set; }
        public ICollection<SavedSubject>? SavedSubjects { get; set; }
        public Subject(Guid id, 
            Guid ownerId, 
            string name, 
            bool privat, 
            string? description, 
            string? photoBase64)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
            Privat = privat;
            Description = description;
            PhotoBase64 = photoBase;
        }
    }
}