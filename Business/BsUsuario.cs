using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BsUsuario : IBsUsuario
    {
        public readonly ApiDBContext context = null;
        public BsUsuario(ApiDBContext context)
        {
            context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> agregarUsuario(Usuario usuario)
        {
            int resultado;
            try
            {
                
                var item = new CtUsuario
                {
                    ClaveUsuario = usuario.ClaveUsuario,
                    Nombre = usuario.Nombre,
                    ApellidoPaterno = usuario.ApellidoPaterno,
                    ApellidoMaterno = usuario.ApellidoMaterno
                };

                context.CtUsuario.Add(item);
                resultado = await context.SaveChangesAsync();
                return resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
