using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public class ApplicationUserRepository : BaseRepository<ApplicationDbContext>, IApplicationUserRepository
    {

        public ApplicationUserRepository(ApplicationDbContext context):base(context)
        {

        }

    }
}
