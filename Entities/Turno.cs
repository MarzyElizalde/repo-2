using Data;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class Turno
    {
        public string IdTurno { get; set; }
        public string IdUsuario { get; set; }
        public DateTime FechaHoraApertura { get; set; }
        public DateTime FechaHoraCierre { get; set; }
        public decimal FondoFijo { get; set; }
        public decimal FondoVenta { get; set; }
        public decimal TotalCierre { get; set; }
        public bool EntregaCompleta { get; set; }
        public List<Fondo> ItemsFondo { get; set; }
    }
}
