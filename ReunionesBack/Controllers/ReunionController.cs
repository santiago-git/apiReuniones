using ReunionesBack.dao;
using ReunionesBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReunionesBack.Controllers
{
    [RoutePrefix("reunion")]
    public class ReunionController : ApiController
    {
        // GET: api/Reunion
        [Route("listartodas")]
        [HttpGet]
        public IEnumerable<Reunion> GET(int id)
        {

            System.Diagnostics.Debug.WriteLine(id);
            OperReunionIm oper = new OperReunionIm();

            return oper.listar();
        }

        [Route("reunionusuario/{idOwner}")]
        [HttpGet]
        public IEnumerable<Reunion> GETReunionesUsuario(int idOwner)
        {
            OperReunionIm oper = new OperReunionIm();
            return oper.listarReunionesUsuario(idOwner);
        }



        // GET: api/Reunion/5
        public Reunion Get(int id)
        {
            OperReunionIm oper = new OperReunionIm();

            return oper.consultar(id);
        }

        // POST: api/Reunion
        [Route("crearreunion")]
        [HttpPost]
        public int crearReunion([FromBody]Reunion r)
        {
            OperReunionIm oper = new OperReunionIm();
            int n=oper.crear(r);
            System.Diagnostics.Debug.WriteLine(n);
            return n;
        }

        // PUT: api/Reunion/5
        public int Put(int id, [FromBody]Reunion r)
        {
            OperReunionIm oper = new OperReunionIm();
            int n = oper.actualizar(id, r);
            return n;
        }

        // DELETE: api/Reunion/5
        [Route("{idReunion}")]
        [HttpDelete]
        public int Delete(int idReunion)
        {
            OperReunionIm oper = new OperReunionIm();
            int n = oper.eliminar(idReunion);
            return n;
        }
    }
}
