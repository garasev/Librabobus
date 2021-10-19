using System;

namespace Librabobus.Backend.Models.Subject
{
    public class SubjectPreviewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? PhotoBase64 { get; set; }

        public SubjectPreviewModel(Guid id,
            string name,
            string photoBase64)
        {
            Id = id;
            Name = name;
            PhotoBase64 = photoBase64;
        }
    }
}