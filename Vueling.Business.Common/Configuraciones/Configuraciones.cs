using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Vueling.Business.Common;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Models;

namespace Vueling.Common.Logic.Utils
{
    public static class Configuraciones
    {
        #region Atributos
        private static ILogger logger = CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        #region Conexion Base de datos
        public static string LeerConexionBaseDeDatos()
        {
            return Environment.GetEnvironmentVariable("ConexionVueling3CapasDB", EnvironmentVariableTarget.User);
        }
        #endregion

        
        public static string ReadValueFromWebConfig(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (ConfigurationErrorsException exception)
            {
                throw;
            }
        }


        #region ConfigurarLogger
        public static ILogger CreateInstanceClassLog(Type typeDeclaring)
        {
            try
            {
                var tipoLog = Environment.GetEnvironmentVariable("Logger", EnvironmentVariableTarget.User);
                var key = ReadValueFromWebConfig(tipoLog);

                Type t = Assembly.GetExecutingAssembly().GetType(key);

                object[] mParam = new object[] { typeDeclaring };
                return (ILogger)Activator.CreateInstance(t, mParam);
            }
            catch (ArgumentNullException exception)
            {
                throw new Exception(exception.Message, exception.InnerException);
            }
            catch (ArgumentException exception)
            {
                throw new Exception(exception.Message, exception.InnerException);
            }

        }
        #endregion
    }
}

