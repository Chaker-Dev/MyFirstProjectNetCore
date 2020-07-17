using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Etudient
    {
        public int IdEtudient { get; set; }
        public string NomEtudient { get; set; }
        public string PrenomEtudient { get; set; }
        public int NumeroInscription { get; set; }
        public int IdGroupe { get; set; }

        public virtual Groupe IdGroupeNavigation { get; set; }
    }
}
