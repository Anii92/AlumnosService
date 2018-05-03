using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Logic.Interfaces;


namespace Vueling.Business.Common.Loggers
{
    public class Log4NetAdapter : ILogger
    {
        private readonly log4net.ILog logger;

        public Log4NetAdapter(Type typeDeclaring)
        {
            this.logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void Debug(object message)
        {
            this.logger.Debug(message.ToString());
        }

        public void Error(object message)
        {
            this.logger.Error(message.ToString());
        }

        public void Fatal(object message)
        {
            this.logger.Fatal(message.ToString());
        }

        public void Info(object message)
        {
            this.logger.Info(message.ToString());
        }

        public void Warn(object message)
        {
            this.logger.Warn(message.ToString());
        }
    }
}
