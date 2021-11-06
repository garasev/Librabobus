using System;
using System.Collections.Generic;
using Librabobus.Backend.Dtos.Record;
using Librabobus.Backend.Models.Record;

namespace Librabobus.Backend.Dtos.Subject
{
    public class SubjectDto
    {
        public Guid Id { get; }
        public Guid OwnerId { get; }
        public string Name { get; set; }
        public bool Privat { get; set; }
        public string? Description { get; set; }
        public string? PhotoBase64 { get; set; }
        
        public List<RecordDto>? Records { get; set; }

        public SubjectDto(Guid id, 
            Guid ownerId, 
            string name, 
            bool privat, 
            string? description, 
            string? photoBase64,
            List<RecordDto>? records)
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