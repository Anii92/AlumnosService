using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Interfaces;
using Vueling.Common.Logic.Models;
using Vueling.Common.Logic.Utils;

namespace Vueling.Business.Facade.Service.Controllers
{
    public class AlumnoController : ApiController
    {
        private readonly ILogger logger = Configuraciones.CreateInstanceClassLog(MethodBase.GetCurrentMethod().DeclaringType);
        private IAlumnoBusiness alumnoBusiness;
        
        public AlumnoController(IAlumnoBusiness alumnoBusiness)
        {
            this.alumnoBusiness = alumnoBusiness;
        }
        /// <summary>
        /// Return list of students
        /// </summary>
        /// <returns>List of students</returns>
        [HttpGet()]
        public IHttpActionResult GetAllStudents()
        {
            logger.Debug(string.Format("{0} {1}", ResourcesLogger.startFunction, System.Reflection.MethodBase.GetCurrentMethod().Name));
            IHttpActionResult students = Ok(this.alumnoBusiness.Leer());
            logger.Debug(string.Format("{0} {1}", ResourcesLogger.endFunction, System.Reflection.MethodBase.GetCurrentMethod().Name));
            return students;
        }

        [HttpGet()]
        public IHttpActionResult GetStudentById(int id)
        {
            logger.Debug(string.Format("{0} {1}", ResourcesLogger.startFunction, System.Reflection.MethodBase.GetCurrentMethod().Name));
            IHttpActionResult student = Ok(this.alumnoBusiness.LeerById(id));
            logger.Debug(string.Format("{0} {1}", ResourcesLogger.endFunction, System.Reflection.MethodBase.GetCurrentMethod().Name));
            return student;
        }

        [HttpDelete()]
        public IHttpActionResult DeleteStudentById(int id)
        {
            try
            {
                return Ok(this.alumnoBusiness.DeleteById(id));
            }
            catch (Exception exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost()]
        public IHttpActionResult CreateStudent(Alumno alumno)
        {
            try
            {
                return Ok(this.alumnoBusiness.Create(alumno));
            }
            catch (Exception exception)
            {
                return InternalServerError();
            }
        }
    }
}
