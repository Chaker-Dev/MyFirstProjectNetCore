using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class AssociationGroupeProf
    {
        public int? IdGroupe { get; set; }
        public int? IdProf { get; set; }

        public virtual Groupe IdGroupeNavigation { get; set; }
        public virtual Professeur IdProfNavigation { get; set; }
    }
}
