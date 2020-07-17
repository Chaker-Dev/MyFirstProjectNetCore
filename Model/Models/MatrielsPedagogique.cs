using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class MatrielsPedagogique
    {
        public int IdMatriel { get; set; }
        public string NomMatriel { get; set; }
        public string RefMatriel { get; set; }
        public int? NombreMatriel { get; set; }
        public int? IdSalle { get; set; }

        public virtual Salle IdSalleNavigation { get; set; }
    }
}
