using LOGIC.Contracts;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LOGIC
{
    public class SalleRepository : GenericRepository<Salle>, ISalleRepository
    {
        private readonly SchoolDBContext _schoolDBContext;
        public SalleRepository(SchoolDBContext schoolDBContext) : base(schoolDBContext)
        {
            _schoolDBContext = schoolDBContext;
        }

        public IEnumerable<Salle> GetAllSalleTP()
        {
            return (from m in this._schoolDBContext.Salle where m.TypeSalle == "TP" select m);
        }
    }
}
