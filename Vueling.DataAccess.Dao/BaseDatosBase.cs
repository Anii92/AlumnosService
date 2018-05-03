using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Utils;

namespace Vueling.DataAccess.Dao
{
    public abstract class BaseDatosBase
    {
        protected string Conexion { get; set; }

        protected BaseDatosBase()
        {
            this.Conexion = Configuraciones.LeerConexionBaseDeDatos();
        }
    }
}
