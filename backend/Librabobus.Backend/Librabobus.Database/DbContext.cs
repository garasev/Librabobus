using System;
using Microsoft.EntityFrameworkCore;

namespace Librabobus.Database
{
    public class LibrabobusDbContext: DbContext
    {
        public LibrabobusDbContext(DbContextOptions<LibrabobusDbContext> options) : base(options)
        {
        }
        
        
    }
}