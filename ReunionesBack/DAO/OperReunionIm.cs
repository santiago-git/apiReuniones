using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReunionesBack.Models;
using Newtonsoft.Json;

namespace ReunionesBack.dao
{
    public class OperReunionIm : OperReunion
    {
        public int actualizar(int id, Reunion r)
        {
            ReunionesDBEntities db = new ReunionesDBEntities();

            try
            {
                Reunion reunion = db.Reunion.First(i=> i.id==id);
                reunion.nombre = r.nombre;
                reunion.owner = r.owner;
                reunion.descripcion = r.descripcion;
                reunion.fecha = r.fecha;

                int n = db.SaveChanges();
                return n;
            }
            catch
            {
                return 0;
            }
        }

        public Reunion consultar(long pk)
        {
            ReunionesDBEntities db = new ReunionesDBEntities();

            Reunion r = db.Reunion.Find(pk);

            Reunion reunion = new Reunion();

            if (r == null)
            {
                return null;
            }

            reunion.nombre = r.nombre;
            reunion.id = r.id;
            reunion.owner = r.owner;
            reunion.descripcion = r.descripcion;
            reunion.fecha = r.fecha;

            return reunion;
        }

        public int crear(Reunion r)
        {
            ReunionesDBEntities db = new ReunionesDBEntities();
            
            try {
                db.Reunion.Add(r);
                return db.SaveChanges();
            } catch
            {
                return 0;
            }
        }

        public int eliminar(int pk)
        {
            ReunionesDBEntities db = new ReunionesDBEntities();

            Reunion r = new Reunion() { id = pk };
            try
            {
                db.Reunion.Attach(r);
                db.Reunion.Remove(r);
                return db.SaveChanges();
            }
            catch
            {
                return 0;
            }
        }

        public IEnumerable<Reunion> listar()
        {
            ReunionesDBEntities db = new ReunionesDBEntities();

            List<Reunion> reuniones = db.Reunion.ToList();

            List<Reunion> reus = new List<Reunion>();
            foreach (Reunion l in reuniones)
            {
                //System.Diagnostics.Debug.WriteLine(l.nombre.ToString());

                Reunion r = new Reunion();
                r.id = l.id;
                r.nombre = l.nombre;
                r.fecha = l.fecha;
                r.owner = l.owner;
                r.descripcion = l.descripcion;
                r.Estados_reunion_usuario=l.Estados_reunion_usuario;

                reus.Add(r);
            }

            return reus;
        }



        public List<Reunion> listarReunionesUsuario(int idOwner)
        {
            ReunionesDBEntities db = new ReunionesDBEntities();


            var reuniones = from r in db.Reunion
                        where r.owner.Equals(idOwner)
                        select r;

            //List<Reunion> reuniones = db.Reunion.Where(reunion => reunion.id== owner).ToList();

            List<Reunion> reus = new List<Reunion>();
            foreach (Reunion l in reuniones)
            {
                //System.Diagnostics.Debug.WriteLine(l.nombre.ToString());

                Reunion r = new Reunion();
                r.id = l.id;
                r.nombre = l.nombre;
                r.owner = l.owner;
                r.descripcion = l.descripcion;
                r.fecha = l.fecha;

                reus.Add(r);
            }
            return reus;
        }



        List<Reunion> OperReunion.listar()
        {
            throw new NotImplementedException();
        }
    }
}