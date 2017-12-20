using ReunionesBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReunionesBack.dao
{
    public interface OperUsuario
    {
        List<Usuario> listar();
        Usuario login(Usuario us);
    }
}
