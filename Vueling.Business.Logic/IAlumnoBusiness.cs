using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;

namespace Vueling.Business.Logic
{
    public interface IAlumnoBusiness
    {
        List<Alumno> Leer();
        Alumno LeerById(int id);
        int DeleteById(int id);
        Alumno Create(Alumno alumno);
    }
}
