using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;
using Vueling.DataAccess.Dao.Daos;

namespace Vueling.Business.Logic
{
    public class AlumnoBL : IAlumnoBL
    {
        private AlumnoDao alumnoDao;

        public AlumnoBL()
        {
            this.alumnoDao = new AlumnoDao();
        }
        public List<Alumno> Leer()
        {
            try
            {
                List<Alumno> alumnos = this.alumnoDao.Leer();
                return alumnos;
            }
            catch (Exception exception)
            {
                //this.logger.Error(exception.Message + exception.StackTrace);
                throw;
            }
        }
    }
}
