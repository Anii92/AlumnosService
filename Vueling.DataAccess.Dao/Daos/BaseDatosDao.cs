using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.Dao.Interfaces;

namespace Vueling.DataAccess.Dao.Daos
{
    public class BaseDatosDao : Repositorio
    {
        private string Conexion { get; set; }
        //private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        public BaseDatosDao(IRead read): base(read)
        {
            this.Conexion = Configuraciones.LeerConexionBaseDeDatos();
        }


        public override List<Alumno> Read()
        {
            try
            {
                //this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List <Alumno> alumnos = this.read.Read();
                //this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnos;
            }
            catch (InvalidOperationException exception)
            {
                //this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (SqlException exception)
            {
                //this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (InvalidCastException exception)
            {
                //this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public override Alumno Add(Alumno alumno)
        {
            throw new NotImplementedException();
        }

        public override object ReadByGuid(string guid)
        {
            throw new NotImplementedException();
        }
    }
}
