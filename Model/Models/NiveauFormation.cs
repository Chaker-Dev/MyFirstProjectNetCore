using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class NiveauFormation
    {
        public NiveauFormation()
        {
            Filiere = new HashSet<Filiere>();
        }

        public int IdNiveau { get; set; }
        public string NomNiveau { get; set; }
        public int IdFormation { get; set; }

        public virtual Formation IdFormationNavigation { get; set; }
        public virtual ICollection<Filiere> Filiere { get; set; }
    }
}
