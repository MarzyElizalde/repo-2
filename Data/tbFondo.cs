using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public partial class TbFondo
    {
        public long PKIdFondo { get; set; }
        public long FKIdTurno { get; set; }
        public long FKIdDenominacion { get; set; }
        public long FKIdTipoMovimiento { get; set; }
        public long Cantidad { get; set; }

        public virtual TbTurno FKIdTurnoNavigation { get; set; }
        public virtual CtDenominacion FKIdDenominacionNavigation { get; set; }
        public virtual CtTipoMovimiento FKIdTipoMovimientoNavigation { get; set; }
    }
}
