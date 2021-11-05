using System;

namespace Librabobus.Backend.Dtos.Record
{
    public class RecordDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Content { get; set; }
        public string? KeyWords { get; set; }

        public RecordDto(Guid id,
            string name,
            int type,
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