using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class AssociationSalleGroupe
    {
        public int IdSalle { get; set; }
        public int IdGroupe { get; set; }
        public string Observations { get; set; }

        public virtual Groupe IdGroupeNavigation { get; set; }
        public virtual Salle IdSalleNavigation { get; set; }
    }
}
