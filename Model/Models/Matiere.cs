using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Matiere
    {
        public int IdMatiere { get; set; }
        public string NomMatiere { get; set; }
        public int? IdFiliere { get; set; }
    }
}
