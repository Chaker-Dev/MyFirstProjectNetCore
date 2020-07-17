using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Salle
    {
        public Salle()
        {
            MatrielsPedagogique = new HashSet<MatrielsPedagogique>();
        }

        public int IdSalle { get; set; }
        public string NomSalle { get; set; }
        public string TypeSalle { get; set; }
        public string CapaciterSalle { get; set; }

        public virtual ICollection<MatrielsPedagogique> MatrielsPedagogique { get; set; }
    }
}
