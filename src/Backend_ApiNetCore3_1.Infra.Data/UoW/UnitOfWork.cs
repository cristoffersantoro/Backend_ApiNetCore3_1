using Backend_ApiNetCore3_1.Domain.Interfaces;
using Backend_ApiNetCore3_1.Infra.Data.Context;

namespace Backend_ApiNetCore3_1.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Backend_ApiNetCore3_1Context _context;


        public UnitOfWork(Backend_ApiNetCore3_1Context context)
        {
            _context = context;
        }



        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
