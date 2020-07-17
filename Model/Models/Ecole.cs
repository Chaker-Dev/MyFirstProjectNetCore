using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Ecole
    {
        public Ecole()
        {
            AnnéeUniversitaire = new HashSet<AnnéeUniversitaire>();
            Formation = new HashSet<Formation>();
        }

        public int IdEcole { get; set; }
        public string NomEcole { get; set; }
        public string LogoEcole { get; set; }

        public virtual ICollection<AnnéeUniversitaire> AnnéeUniversitaire { get; set; }
        public virtual ICollection<Formation> Formation { get; set; }
    }
}
