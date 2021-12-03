using System;
using System.Collections.Generic;

#nullable disable

namespace u3_aspnetcore_efcore_18100220.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            InstrumentoMusicals = new HashSet<InstrumentoMusical>();
        }

        public int IdTipo { get; set; }
        public string NombreTipo { get; set; }

        public virtual ICollection<InstrumentoMusical> InstrumentoMusicals { get; set; }
    }
}
