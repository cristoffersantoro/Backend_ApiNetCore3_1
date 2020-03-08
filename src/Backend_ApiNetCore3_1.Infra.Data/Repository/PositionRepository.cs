using Microsoft.EntityFrameworkCore;
using Backend_ApiNetCore3_1.Domain.Core.Models;
using Backend_ApiNetCore3_1.Domain.Interfaces;
using Backend_ApiNetCore3_1.Domain.Models;
using Backend_ApiNetCore3_1.Infra.Data.Context;
using System.Linq;

namespace Backend_ApiNetCore3_1.Infra.Data.Repository
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        public PositionRepository(Backend_ApiNetCore3_1Context context)
            : base(context)
        {

        }

    }
}
