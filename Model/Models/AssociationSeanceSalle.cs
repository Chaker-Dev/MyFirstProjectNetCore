using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class AssociationSeanceSalle
    {
        public int IdSeance { get; set; }
        public int IdSalle { get; set; }

        public virtual Salle IdSalleNavigation { get; set; }
        public virtual Seance IdSeanceNavigation { get; set; }
    }
}
