using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;

namespace Vueling.DataAccess.Dao.Interfaces
{
    public interface IAlumnoDao: IRead, IDelete
    {
        List<Alumno> ReadAll();
        Alumno ReadById(int id);
        Alumno DeleteById(int id);
    }
}
