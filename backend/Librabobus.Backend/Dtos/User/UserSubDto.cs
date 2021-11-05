using System;

namespace Librabobus.Backend.Dtos.User
{
    public class UserSubDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? PhotoBase64 { get; set; }
        
        public UserSubDto(Guid id,
            string name,
            string photoBase64)
        {
            Id = id;
            Name = name;
            PhotoBase64 = photoBase64;
        }
    }
}