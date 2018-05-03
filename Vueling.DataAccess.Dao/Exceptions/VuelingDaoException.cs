using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.DataAccess.Dao.Exceptions
{
    public class VuelingDaoException : Exception
    {
        public VuelingDaoException()
        {
        }

        public VuelingDaoException(string message) : base(message)
        {
        }

        public VuelingDaoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
