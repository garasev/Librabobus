using System;

namespace Librabobus.Backend.Dtos.Subject
{
    public class SubjectPreviewDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? PhotoBase64 { get; set; }

        public SubjectPreviewDto(Guid id,
            string name,
            string photoBase64)
        {
            Id = id;
            Name = name;
            PhotoBase64 = photoBase64;
        }
    }
}