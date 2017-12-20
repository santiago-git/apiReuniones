using ReunionesBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReunionesBack.dao
{
    public interface OperReunion
    {
        int crear(Reunion r);
        List<Reunion> listar();
        List<Reunion> listarReunionesUsuario(int idOwner);
        Reunion consultar(long pk);
        int eliminar(int pk);
        int actualizar(int pk, Reunion r);
    }
}
