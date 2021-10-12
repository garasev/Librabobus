using System;
using System.Collections.Generic;
#nullable enable

namespace Librabobus.Database.Models
{
    public class SavedSubject
    {
        public Guid UserId { get; set }
        public Guid SubjectId { get; set }
        public SavedSubject(Guid userId, 
            Guid subjectId)
        {
            UserId = userId;
            SubjectId = subjectId;
        }
    }
}