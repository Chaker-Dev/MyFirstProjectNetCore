using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class AssociationSeanceGroupe
    {
        public int IdSeance { get; set; }
        public int IdGroupe { get; set; }

        public virtual Groupe IdGroupeNavigation { get; set; }
        public virtual Seance IdSeanceNavigation { get; set; }
    }
}
