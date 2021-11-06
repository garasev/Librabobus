using System;

namespace Librabobus.Backend.Repositories.Impl.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}