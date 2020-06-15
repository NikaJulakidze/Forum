using Forum.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Uow
{
    public class ApplicationUserUow : BaseUow, IApplicationUserUow
    {
        public ApplicationUserUow(ApplicationDbContext context,IApplicationUserRepository applicationUserRepository):base(context)
        {
            ApplicationUserRepository = applicationUserRepository;
        }
        public IApplicationUserRepository ApplicationUserRepository { get; }
    }
}
