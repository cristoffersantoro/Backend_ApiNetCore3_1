using Backend_ApiNetCore3_1.Domain.Interfaces;
using Backend_ApiNetCore3_1.Domain.Models;
using Backend_ApiNetCore3_1.Infra.Data.Context;

namespace Backend_ApiNetCore3_1.Infra.Data.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(Backend_ApiNetCore3_1Context context)
            : base(context)
        {

        }
    }
}
