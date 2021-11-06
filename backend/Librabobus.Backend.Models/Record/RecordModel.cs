using System;
using Librabobus.Backend.Models.Enums;

namespace Librabobus.Backend.Models.Record
{
    public class RecordModel
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public TypeRecordModel Type { get; set; }
        public string Content { get; set; }
        public string? KeyWords { get; set; }

        public RecordModel(Guid id,
            Guid subjectId,
            string name,
            TypeRecordModel type,
            string content,
            string keyWords)
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