using ReunionesBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReunionesBack.DAO
{
    interface OperEstadosReunionUsuario
    {
        List<Estados_reunion_usuario> listarTodas();
        int crearInvitacionesPorOwner(List<Estados_reunion_usuario> l);
        List<Estados_reunion_usuario> listarInvitacionesUsuario(int idUsuario);
    }
}
