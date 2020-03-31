using Data;
using Entities;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Business
{
    public class BsTurno : IBsTurno
    {
        private readonly ApiDBContext context = null;
        public BsTurno(ApiDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> agregaTurnoJsonAsync(Turno turno)
        {
            int resultado;
            try
            {
                var itemTurno = new TbTurno
                {
                    IdUsuario = turno.IdUsuario,
                    FechaHoraApertura = Convert.ToDateTime(turno.FechaHoraApertura),
                    FechaHoraCierre = Convert.ToDateTime(turno.FechaHoraCierre),
                    FondoFijo = Convert.ToDecimal(turno.FondoFijo),
                    FondoVenta = Convert.ToDecimal(turno.FondoVenta),
                    TotalCierre = Convert.ToDecimal(turno.TotalCierre),
                    EntregaCompleta = turno.EntregaCompleta
                };
                context.TbTurno.Add(itemTurno);
                resultado = await context.SaveChangesAsync();

                foreach(Fondo fondo in turno.ItemsFondo)
                {
                    var itemFondo = new TbFondo
                    {
                        FKIdDenominacion = fondo.IdDenominacion,
                        FKIdTipoMovimiento = fondo.IdTipoMovimiento,
                        FKIdTurno = itemTurno.PKIdTurno,
                        Cantidad = fondo.Cantidad
                    };
                    context.TbFondo.Add(itemFondo);
                    var res = await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var message = $"Ocurrio un error al registrar el turno con Id de Usuario : {turno.IdUsuario}";
                throw new IOException(message, e);
            }
            return resultado;
        }
    }
}
