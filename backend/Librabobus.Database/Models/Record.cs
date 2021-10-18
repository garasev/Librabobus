using System;
using Librabobus.Database.Enums;
#nullable enable

namespace Librabobus.Database.Models
{
    public class Record
    {
        public Guid Id { get; }
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public TypeRecord Type { get; set; }
        public string Content { get; set; }
        public string? KeyWords { get; set; }
        
        public Subject? Subject { get; set; }

        public Record(Guid id, 
            Guid subjectId,
            string name,
            TypeRecord type, 
            string content,
            string? keyWords)
        {
            Id = id;
            SubjectId = subjectId;
            Name = name;
            Type = type;
            Content = content;
            KeyWords = keyWords;
        }
    }
}