using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReunionesBack.Models;

namespace ReunionesBack.DAO
{
    public class OperEstadosReunionUsuarioIm : OperEstadosReunionUsuario
    {
        private ReunionesDBEntities db = new ReunionesDBEntities();

        public List<Estados_reunion_usuario> listarTodas()
        {
            List<Estados_reunion_usuario> estados = db.Estados_reunion_usuario.ToList();

            List<Estados_reunion_usuario> EstReuUs = new List<Estados_reunion_usuario>();

            foreach (Estados_reunion_usuario estado in estados)
            {
                Estados_reunion_usuario est = new Estados_reunion_usuario();

                est.id_usuario = estado.id_usuario;
                est.id_estado_reunion = estado.id_estado_reunion;
                est.id_reunion = estado.id_reunion;
                est.vigencia = estado.vigencia;


                System.Diagnostics.Debug.WriteLine(estado.Usuario.correo);

                EstReuUs.Add(est);
            }

            return EstReuUs;
        }

        public int crearInvitacionesPorOwner(List<Estados_reunion_usuario> l)
        {
            if (l != null)
            {

                try
                {
                    db.Estados_reunion_usuario.AddRange(l);
                    return db.SaveChanges();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    return 0;
                }

    
            }
            return 0;
        }

        public List<Estados_reunion_usuario> listarInvitacionesUsuario(int idUsuario)
        {
            List<Estados_reunion_usuario> estadosUs = db.Estados_reunion_usuario
                .Where(tabla => tabla.id_usuario == idUsuario)
                .Where(tabla => tabla.vigencia == 1)
                .ToList();

            List<Estados_reunion_usuario> prueba = db.Estados_reunion_usuario.Join(db.Reunion, c => c.id_reunion, cm => cm.id, (c, cm) => new { id = c.id_reunion }).ToList();

            List<Estados_reunion_usuario> EstReuUs = new List<Estados_reunion_usuario>();
            foreach (Estados_reunion_usuario estado in estadosUs)
            {

                Usuario u = new Usuario();
                u.id = estado.Usuario.id;
                u.nombre = estado.Usuario.nombre;
                u.correo = estado.Usuario.correo;
                u.contrasena = estado.Usuario.contrasena;

                Reunion r = new Reunion();
                r.id = estado.Reunion.id;
                r.nombre = estado.Reunion.nombre;
                r.descripcion = estado.Reunion.descripcion;
                r.owner = estado.Reunion.owner;
                r.fecha = estado.Reunion.fecha;
                r.Usuario=u;


                Estados_reunion_usuario est = new Estados_reunion_usuario {
                    id_usuario = estado.id_usuario,
                    id_estado_reunion =estado.id_estado_reunion,
                    id_reunion =estado.id_reunion,
                    vigencia =estado.vigencia,
                    Reunion=r
                };

                EstReuUs.Add(est);
            }
            return EstReuUs;
        }
    }
}