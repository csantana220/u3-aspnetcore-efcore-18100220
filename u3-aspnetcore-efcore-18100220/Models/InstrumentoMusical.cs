using System;
using System.Collections.Generic;

#nullable disable

namespace u3_aspnetcore_efcore_18100220.Models
{
    public partial class InstrumentoMusical
    {
        public int IdInstrumento { get; set; }
        public string Nombre { get; set; }
        public int? IdTipo { get; set; }

        public virtual Tipo IdTipoNavigation { get; set; }
    }
}
