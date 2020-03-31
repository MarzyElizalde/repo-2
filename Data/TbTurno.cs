using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TbTurno
    {
        public TbTurno()
        {
            TbFondo = new HashSet<TbFondo>();
        }

        public long PKIdTurno { get; set; }
        public string IdUsuario { get; set; }
        public DateTime FechaHoraApertura { get; set; }
        public DateTime FechaHoraCierre { get; set; }
        public decimal FondoFijo { get; set; }
        public decimal FondoVenta { get; set; }
        public decimal TotalCierre { get; set; }
        public bool EntregaCompleta { get; set; }

        public virtual ICollection<TbFondo> TbFondo { get; set; }
    }
}
