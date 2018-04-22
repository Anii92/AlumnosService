using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
    public class AlumnoDao : IAlumnoDao
    {
        //private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        public List<Alumno> Leer()
        {
            try
            {
                BaseDatosDao baseDatosDao = new BaseDatosDao(new ReadBaseDatos());
                List<Alumno> alumnos = baseDatosDao.Read();
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
            catch (NullReferenceException exception)
            {
                //this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        
    }
}
