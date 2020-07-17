using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Groupe
    {
        public Groupe()
        {
            Etudient = new HashSet<Etudient>();
        }

        public int IdGroupe { get; set; }
        public string NomGroupe { get; set; }
        public int NombreGroupe { get; set; }
        public int IdFiliere { get; set; }

        public virtual Filiere IdFiliereNavigation { get; set; }
        public virtual ICollection<Etudient> Etudient { get; set; }
    }
}
