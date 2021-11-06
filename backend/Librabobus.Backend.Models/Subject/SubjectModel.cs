using System;
using System.Collections.Generic;
using Librabobus.Backend.Models.Record;
using Librabobus.Database.Models;

namespace Librabobus.Backend.Models.Subject
{
    public class SubjectModel
    {
        public Guid Id { get; }
        public Guid OwnerId { get; }
        public string Name { get; set; }
        public bool Privat { get; set; }
        public string? Description { get; set; }
        public string? PhotoBase64 { get; set; }
        public List<RecordModel>? Records { get; set; }
        
        public SubjectModel(Guid id, 
            Guid ownerId, 
            string name, 
            bool privat, 
            string? description, 
            string? photoBase64,
            List<RecordModel>? records)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
            Privat = privat;
            Description = description;
            PhotoBase64 = photoBase64;
            Records = records;
        }
    }
}