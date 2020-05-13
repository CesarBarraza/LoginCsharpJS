using System;
using System.Collections.Generic;
using System.Web.Http;
using Taller.BussinesLogic;
using Taller.Domain;

namespace WebAPIClientes
{
    public class LoginController : ApiController
    {
        // POST api/<controller>
        public string Post([FromBody]Usuario usuario)
        {
            var intententos = 0;
            string result = "";
            DateTime fecha = DateTime.Now;
            List<Usuario> lista = UsuariosManager.Get();

            foreach (Usuario user in lista)
            {
                if (user.User == usuario.User && user.Clave == usuario.Clave) {
                    result = "Usuario autenticado";
                    UsuariosManager.Actualizar(usuario);
                    DateTime fLogin = DateTime.Parse(user.FechaLogin);
                    fLogin = fecha;
                }
                else if(user.NLogins>=3)
                {
                    result = "Se paso del limites de intentos";
                }
                else
                {
                    result = "Usuario o clave incorrecta";
                    user.NLogins = intententos + 1;
                }
            }
            return result;
        }
    }
}