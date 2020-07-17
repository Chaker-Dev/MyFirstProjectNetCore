using Model.Models;
using System.Collections.Generic;

namespace LOGIC.Contracts
{
    public interface ISalleRepository
    {
        IEnumerable<Salle> GetAllSalleTP();
    }
    
}
