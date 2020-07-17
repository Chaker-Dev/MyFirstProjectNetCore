using LOGIC.Contracts;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolDBContext _schoolDBContext;
        public SalleRepository salleRepository { get; private set; }
        public UnitOfWork(SchoolDBContext schoolDBContext)
        {
            _schoolDBContext = schoolDBContext;
             salleRepository = new SalleRepository(_schoolDBContext);
        }
        public async Task Commit()
        {
            await _schoolDBContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _schoolDBContext.Dispose();
        }
    }
}
