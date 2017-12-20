using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReunionesBack.Models;
using Newtonsoft.Json;

namespace ReunionesBack.dao
{
    public class OperUsuarioIm : OperUsuario
    {
        public List<Usuario> listar()
        {
            ReunionesDBEntities db = new ReunionesDBEntities();

            List<Usuario> usuarios = db.Usuario.ToList();

            List<Usuario> users = new List<Usuario>();
            foreach (Usuario u in usuarios)
            {
                Usuario us = new Usuario();
                us.id = u.id;
                us.nombre = u.nombre;
                us.correo = u.correo;
                us.contrasena = u.contrasena;
                us.Estados_reunion_usuario = null;

                users.Add(us);
            }

            return users;
        }

        public Usuario login(Usuario us)
        {
            ReunionesDBEntities db = new ReunionesDBEntities();

            Usuario usuario =db.Usuario.Where(tabla => tabla.correo==us.correo)
                .Where(tabla => tabla.contrasena == us.contrasena)
                .SingleOrDefault();

            if (usuario!=null)
            {
                Usuario user = new Usuario();
                user.id = usuario.id;
                user.correo = usuario.correo;
                user.contrasena = usuario.contrasena;
                user.nombre = usuario.nombre;
                user.Estados_reunion_usuario = null;
                user.Reunion = null;
                return user;
            }

            return null;
        }
    }
}