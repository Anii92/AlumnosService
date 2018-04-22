using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Models;

namespace Vueling.Business.Facade.Service.Controllers
{
    public class AlumnoController : ApiController
    {
        private IAlumnoBL alumnoBL = new AlumnoBL();
        [HttpGet()]
        public IHttpActionResult GetAllStudents()
        {
            try
            {
                return Ok(this.alumnoBL.Leer());
            }
            catch (Exception exception)
            {
                return InternalServerError();
            }
        }
    }
}
