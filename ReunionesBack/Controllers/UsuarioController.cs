using ReunionesBack.dao;
using ReunionesBack.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ReunionesBack.Controllers
{
    [RoutePrefix("usuario")]
    public class UsuarioController : ApiController
    {
        [Route("listar")]
        [HttpGet]
        [ResponseType(typeof(List<Usuario>))]
        public IEnumerable<Usuario> Get()
        {
            OperUsuarioIm operU = new OperUsuarioIm();
            return operU.listar();          
        }

        [Route("login")]
        [HttpPost]
        public Usuario LoginUsuario([FromBody]Usuario usuario)
        {
            OperUsuarioIm operU = new OperUsuarioIm();
            return operU.login(usuario);
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value"+id;
        }

        // POST: api/Usuario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
        }
    }
}
