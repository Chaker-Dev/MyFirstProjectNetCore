using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class AssociationSeanceProfesseur
    {
        public int IdSeance { get; set; }
        public int IdProf { get; set; }

        public virtual Professeur IdProfNavigation { get; set; }
        public virtual Seance IdSeanceNavigation { get; set; }
    }
}
