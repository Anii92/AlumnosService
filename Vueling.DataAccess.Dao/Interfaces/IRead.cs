using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;

namespace Vueling.DataAccess.Dao.Interfaces
{
    public interface IRead
    {
        List<Alumno> ReadAll();
        //Object GetById(int id);
        Alumno ReadByGuid(string guid);
        Alumno ReadById(int id);
    }
}
