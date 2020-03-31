using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class CtUsuario
    {
        public long PKIdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string ClaveUsuario { get; set; }
    }
}
