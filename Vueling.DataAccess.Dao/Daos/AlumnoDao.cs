using System;
using System.Collections.Generic;
using System.Data;
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
    public class AlumnoDao : IRead, IDelete
    {
        //private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        private string Conexion { get; set; }
        private IRead Read { get; set; }
        private IDelete Delete { get; set; }

        public AlumnoDao ()
        {
            this.Conexion = Configuraciones.LeerConexionBaseDeDatos();
        }
        public List<Alumno> ReadAll()
        {
            try
            {
                //this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                List<Alumno> alumnos = new List<Alumno>();
                using (SqlConnection connection = new SqlConnection(this.Conexion))
                {
                    connection.Open();
                    using (SqlCommand myCommand = new SqlCommand("select * from dbo.Alumnos", connection))
                    {
                        SqlDataReader myReader = myCommand.ExecuteReader();
                        while (myReader.Read())
                        {
                            Alumno alumno = new Alumno();
                            alumno.Id = Convert.ToInt32(myReader["Id"]);
                            alumno.Nombre = myReader["Nombre"].ToString();
                            alumno.Apellidos = myReader["Apellidos"].ToString();
                            alumno.Dni = myReader["Dni"].ToString();
                            alumno.FechaNacimiento = Convert.ToDateTime(myReader["FechaNacimiento"]);
                            alumno.Edad = Convert.ToInt32(myReader["Edad"]);
                            alumno.FechaHora = Convert.ToDateTime(myReader["FechaCreacion"]);
                            alumno.Guid = myReader["Guid"].ToString();
                            alumnos.Add(alumno);
                        }
                    }
                }
                //this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
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

        public Alumno ReadById(int id)
        {
            try
            {
                //this.logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Alumno alumno = new Alumno();
                using (SqlConnection connection = new SqlConnection(this.Conexion))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "select * from dbo.Alumnos a where a.Id=@Id";
                        command.Parameters.AddWithValue("@Id", id);

                        connection.Open();
                        SqlDataReader myReader = command.ExecuteReader();
                        while (myReader.Read())
                        {
                            alumno.Id = Convert.ToInt32(myReader["Id"]);
                            alumno.Nombre = myReader["Nombre"].ToString();
                            alumno.Apellidos = myReader["Apellidos"].ToString();
                            alumno.Dni = myReader["Dni"].ToString();
                            alumno.FechaNacimiento = Convert.ToDateTime(myReader["FechaNacimiento"]);
                            alumno.Edad = Convert.ToInt32(myReader["Edad"]);
                            alumno.FechaHora = Convert.ToDateTime(myReader["FechaCreacion"]);
                            alumno.Guid = myReader["Guid"].ToString();
                        }
                    }
                }
                //this.logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumno;
            }
            catch (InvalidOperationException exception)
            {
                throw;
                //this.logger.Error(exception.Message + exception.StackTrace);
                //throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (SqlException exception)
            {
                throw;
                //this.logger.Error(exception.Message + exception.StackTrace);
                //throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
            catch (InvalidCastException exception)
            {
                throw;
                //this.logger.Error(exception.Message + exception.StackTrace);
                //throw new VuelingDaoException(exception.Message, exception.InnerException);
            }
        }

        public Alumno ReadByGuid(string guid)
        {
            return new Alumno();
        }

        public int DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public int DeleteByGuid(string guid)
        {
            throw new NotImplementedException();
        }
    }
}
