using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Models;

namespace Vueling.Common.Logic.Utils
{
    public static class Configuraciones
    {
        #region Conexion Base de datos
        public static string LeerConexionBaseDeDatos()
        {
            return Environment.GetEnvironmentVariable("ConexionVueling3CapasDB", EnvironmentVariableTarget.User);
        }
        #endregion

        
        public static string LeerAppConfig(string key)
        {
            try
            {
                var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string log = configuration.AppSettings.Settings[key].Value;
                return log;
            }
            catch (ConfigurationErrorsException exception)
            {
                throw;
            }
        }
        public static void GuardarAppConfig(string key, string value)
        {
            try
            {
                //logger.Debug(ResourcesLog.startFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings[key]))
                {
                    configuration.AppSettings.Settings.Add(key, value);
                }
                else
                {
                    configuration.AppSettings.Settings[key].Value = value;
                }
                configuration.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("appSettings");
                //logger.Debug(ResourcesLog.endFunction + System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            catch (ConfigurationErrorsException exception)
            {
                //logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }
    }
}

