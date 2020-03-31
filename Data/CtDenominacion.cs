using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public partial class CtDenominacion
    {
        public CtDenominacion()
        {
            TbFondo = new HashSet<TbFondo>();
        }

        public long PKIdDenominacion { get; set; }
        public long FKIdDivisa { get; set; }
        public string Descripcion { get; set; }

        public virtual CtDivisa FkIdDivisaNavigation { get; set; }
        public virtual ICollection<TbFondo> TbFondo { get; set; }
    }
}
