using Backend_ApiNetCore3_1.Domain.Interfaces;
using Backend_ApiNetCore3_1.Domain.Models;
using Backend_ApiNetCore3_1.Infra.Data.Context;

namespace Backend_ApiNetCore3_1.Infra.Data.Repository
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(Backend_ApiNetCore3_1Context context)
            : base(context)
        {

        }

    }
}
