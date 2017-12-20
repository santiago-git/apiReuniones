using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ReunionesBack.Models;
using ReunionesBack.DAO;

namespace ReunionesBack.Controllers
{
    public class Estados_reunion_usuarioController : ApiController
    {
        private ReunionesDBEntities db = new ReunionesDBEntities();

        // GET: api/Estados_reunion_usuario
        public List<Estados_reunion_usuario> GetEstados_reunion_usuario()
        {
            OperEstadosReunionUsuarioIm est = new OperEstadosReunionUsuarioIm();
            return est.listarTodas();
        }

        // GET: api/Estados_reunion_usuario/5
        [ResponseType(typeof(Estados_reunion_usuario))]
        public IHttpActionResult GetEstados_reunion_usuario(int id)
        {
            Estados_reunion_usuario estados_reunion_usuario = db.Estados_reunion_usuario.Find(id);
            if (estados_reunion_usuario == null)
            {
                return NotFound();
            }

            return Ok(estados_reunion_usuario);
        }

        // PUT: api/Estados_reunion_usuario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstados_reunion_usuario(int id, Estados_reunion_usuario estados_reunion_usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estados_reunion_usuario.id_usuario)
            {
                return BadRequest();
            }

            db.Entry(estados_reunion_usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Estados_reunion_usuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Estados_reunion_usuario/2
        [ResponseType(typeof(int))]
        public int PostEstados_reunion_usuario(List<Estados_reunion_usuario> l)
        {
            //System.Diagnostics.Debug.WriteLine(idReunion);
            OperEstadosReunionUsuarioIm est = new OperEstadosReunionUsuarioIm();
            return est.crearInvitacionesPorOwner(l);
        }


        // DELETE: api/Estados_reunion_usuario/5
        [ResponseType(typeof(Estados_reunion_usuario))]
        public IHttpActionResult DeleteEstados_reunion_usuario(int id)
        {
            Estados_reunion_usuario estados_reunion_usuario = db.Estados_reunion_usuario.Find(id);
            if (estados_reunion_usuario == null)
            {
                return NotFound();
            }

            db.Estados_reunion_usuario.Remove(estados_reunion_usuario);
            db.SaveChanges();

            return Ok(estados_reunion_usuario);
        }



        [Route("invitacionesUsuario/{idUsuario}")]
        [HttpGet]
        public IHttpActionResult listarInvitacionesUsuario(int idUsuario)
        {
            OperEstadosReunionUsuarioIm est = new OperEstadosReunionUsuarioIm();

            return Ok(est.listarInvitacionesUsuario(idUsuario));
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Estados_reunion_usuarioExists(int id)
        {
            return db.Estados_reunion_usuario.Count(e => e.id_usuario == id) > 0;
        }
    }
}