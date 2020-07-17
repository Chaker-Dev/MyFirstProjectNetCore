using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class AnnéeUniversitaire
    {
        public AnnéeUniversitaire()
        {
            Semestre = new HashSet<Semestre>();
        }

        public int IdAnneeUn { get; set; }
        public string NomAnneeUn { get; set; }
        public int? IdEcole { get; set; }

        public virtual Ecole IdEcoleNavigation { get; set; }
        public virtual ICollection<Semestre> Semestre { get; set; }
    }
}
