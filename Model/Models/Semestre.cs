using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Semestre
    {
        public int IdSemestre { get; set; }
        public string NomSemestre { get; set; }
        public int IdAnneeUn { get; set; }

        public virtual AnnéeUniversitaire IdAnneeUnNavigation { get; set; }
    }
}
