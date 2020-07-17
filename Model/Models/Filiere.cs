using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Filiere
    {
        public Filiere()
        {
            Groupe = new HashSet<Groupe>();
        }

        public int IdFiliere { get; set; }
        public string NomFiliere { get; set; }
        public int? IdNiveau { get; set; }

        public virtual NiveauFormation IdNiveauNavigation { get; set; }
        public virtual ICollection<Groupe> Groupe { get; set; }
    }
}
