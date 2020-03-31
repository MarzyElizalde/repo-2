using System;
using System.Collections.Generic;

namespace Data
{
    public partial class CtDivisa
    {
        public CtDivisa()
        {
            CtDenominacion = new HashSet<CtDenominacion>();
        }

        public long PkIdDivisa { get; set; }
        public string Divisa { get; set; }

        public virtual ICollection<CtDenominacion> CtDenominacion { get; set; }
    }
}
