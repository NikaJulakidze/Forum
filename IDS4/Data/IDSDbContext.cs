using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDS4.Data
{
    public class IDSDbContext:IdentityDbContext
    {
        public IDSDbContext(DbContextOptions options):base(options)
        {

        }
    }
}
