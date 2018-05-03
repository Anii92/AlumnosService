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

namespace Vueling.DataAccess.Dao.Daos
{
    public class BaseDatosDao: IRead, IDelete, ICreate
    {
        private string Conexion { get; set; }

        private ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);

        public BaseDatosDao()
        {
            this.Conexion = Configuraciones.LeerConexionBaseDeDatos();
        }

        public Alumno Add(Alumno alumno)
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
                        command.CommandText = @"INSERT into dbo.Alumnos (Nombre, Apellidos, Dni, FechaNacimiento, Edad, FechaCreacion, Guid)
                                                VALUES (@nombre, @apellidos, @dni, @fechaNacimiento, @edad, @fechaCreacion, @guid)";
                        command.Parameters.AddWithValue("@nombre", alumno.Nombre);
                        command.Parameters.AddWithValue("@apellidos", alumno.Apellidos);
                        command.Parameters.AddWithValue("@dni", alumno.Dni);
                        command.Parameters.AddWithValue("@fechaNacimiento", alumno.FechaNacimiento);
                        command.Parameters.AddWithValue("@edad", alumno.Edad);
                        command.Parameters.AddWithValue("@fechaCreacion", alumno.FechaHora);
                        command.Parameters.AddWithValue("@guid", alumno.Guid);

                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                        if (recordsAffected == 1)
                        {
                            //en lugar de hacerlo por el id hacerlo por el guid
                            alumnoInsertado = (Alumno)ReadByGuid(alumno.Guid);
                        }
                    }
                }
                this.logger.Debug(ResourcesLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnoInsertado;
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

        public List<Alumno> ReadAll()
        {
            try
            {
                this.logger.Debug(ResourcesLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                this.logger.Debug(ResourcesLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumnos;
            }
            catch (InvalidOperationException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (SqlException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
            catch (InvalidCastException exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public Alumno ReadByGuid(string guid)
        {
            try
            {
                this.logger.Debug(ResourcesLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Alumno alumno = new Alumno();
                using (SqlConnection connection = new SqlConnection(this.Conexion))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "select * from dbo.Alumnos a where a.Guid = @Guid";
                        command.Parameters.AddWithValue("@Guid", guid);

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
                this.logger.Debug(ResourcesLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumno;
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

        Alumno IRead.ReadById(int id)
        {
            try
            {
                this.logger.Debug(ResourcesLogger.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
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
                this.logger.Debug(ResourcesLogger.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return alumno;
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

        public int DeleteByGuid(string guid)
        {
            throw new NotImplementedException();
        }
    }
}
