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
using Vueling.DataAccess.Dao.Exceptions;
using Vueling.DataAccess.Dao.Interfaces;

namespace Vueling.DataAccess.Dao
{
    public class DeleteBaseDatos : BaseDatosBase, IDelete
    {
        private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        public DeleteBaseDatos() : base() { }

        public int DeleteByGuid(string guid)
        {
            throw new NotImplementedException();
        }

        public int DeleteById(int id)
        {
            try
            {
                this.logger.Debug(ResourcesLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Alumno alumnoInsertado = new Alumno();
                using (SqlConnection connection = new SqlConnection(this.Conexion))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = @"DELETE from dbo.Alumnos 
                                                WHERE Id = @Id";
                        command.Parameters.AddWithValue("@Id", id);

                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                        this.logger.Debug(ResourcesLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                        return recordsAffected;
                    }
                }
            }
            catch (InvalidOperationException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (SqlException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (InvalidCastException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
        }
    }
}
