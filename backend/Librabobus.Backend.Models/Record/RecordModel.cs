using System;
using Librabobus.Backend.Models.Enums;

namespace Librabobus.Backend.Models.Record
{
    public class RecordModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TypeRecord Type { get; set; }
        public string Content { get; set; }
        public string? KeyWords { get; set; }

        public RecordModel(Guid id,
            string name,
            TypeRecord type,
            string content,
            string keyWords)
        {
            Id = id;
            Name = name;
            Type = type;
            Content = content;
            KeyWords = keyWords;
        }
    }
}