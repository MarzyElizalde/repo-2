using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public partial class CtTipoMovimiento
    {
        public CtTipoMovimiento()
        {
            TbFondo = new HashSet<TbFondo>();
        }

        public long PKIdTipoMovimiento { get; set; }
        public string TipoMovimiento { get; set; }

        public virtual ICollection<TbFondo> TbFondo { get; set; }
    }
}
