using apiTipoCambio.Entities;
using apiTipoCambio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiTipoCambio.Repositories
{
    public class LoginRepositorio : ILoginRepositorio
    {
        public async Task<dynamic> GetLogin(string pUsuarioId, string pContrasenia)
        {
            var vContrasenia = (pContrasenia);

            var oUsuarioAutentificado = new UsuarioTipoCambioBe()
            {
                UsuarioId = pUsuarioId,
                NombreRol = "RolAdministrador",
                NombreUsu = "Usuario Administrador",
                RolId = "1",
                CorreoEletronico = "randolph.2r@gmail.com"
            };

            return oUsuarioAutentificado;
        }

    }
}
