using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Utils;
using Vueling.DataAccess.Dao.Daos;
using Vueling.DataAccess.Dao.Interfaces;

namespace Vueling.Business.Logic
{
    public class AlumnoBusiness : IAlumnoBusiness
    {
        private readonly ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        private IRead read;
        private IDelete delete;
        private ICreate create;

        public AlumnoBusiness(IRead read, IDelete delete, ICreate create)
        {
            this.read = read;
            this.delete = delete;
            this.create = create;
        }

        public Alumno Create(Alumno alumno)
        {
            try
            {
                return this.create.Add(alumno);
            }
            catch (Exception exception)
            {

                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public int DeleteById(int id)
        {
            try
            {
                return this.delete.DeleteById(id);
            }
            catch (Exception exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public List<Alumno> Leer()
        {
            try
            {
                List<Alumno> alumnos = this.read.ReadAll();
                return alumnos;
            }
            catch (Exception exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }

        public Alumno LeerById(int id)
        {
            try
            {
                Alumno alumno = this.read.ReadById(id);
                return alumno;
            }
            catch (Exception exception)
            {
                this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }
    }
}
