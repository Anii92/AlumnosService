﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Models;

namespace Vueling.DataAccess.Dao.Interfaces
{
    public interface IAlumnoDao
    {
        //Alumno Add(Alumno alumno);
        //void CargarDatosDeLosAlumnos(Formato Formato);
        List<Alumno> Leer();
        //int DeleteByGuid(string guid);
    }
}
