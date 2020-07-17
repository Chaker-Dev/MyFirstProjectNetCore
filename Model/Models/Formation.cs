using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Formation
    {
        public Formation()
        {
            NiveauFormation = new HashSet<NiveauFormation>();
        }

        public int IdFormation { get; set; }
        public string NomFormation { get; set; }
        public string TypeFormation { get; set; }
        public string DureeFormation { get; set; }
        public int? IdEcole { get; set; }

        public virtual Ecole IdEcoleNavigation { get; set; }
        public virtual ICollection<NiveauFormation> NiveauFormation { get; set; }
    }
}
