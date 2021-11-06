using System;
namespace Librabobus.Backend.Repositories.Impl.Exceptions
{
    public class RepositoryConflictException : Exception
    {
        public RepositoryConflictException(string message) : base(message)
        {
        }
    }
}