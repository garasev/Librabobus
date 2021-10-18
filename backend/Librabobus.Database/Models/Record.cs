using System;
using Librabobus.Database.Enums;
#nullable enable

namespace Librabobus.Database.Models
{
    public class Record
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public TypeRecord Type { get; set; }
        public string Content { get; set; }
        public string? KeyWords { get; set; }
        public Record(Guid id, 
            string name,
            TypeRecord type, 
            string content,
            string? keyWords)
        {
            Id = id;
            Name = name;
            Type = type;
            Content = content;
            KeyWords = keyWords;
        }
    }
}