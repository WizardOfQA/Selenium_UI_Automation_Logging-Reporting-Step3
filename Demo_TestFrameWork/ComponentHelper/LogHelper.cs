using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TestFrameWork.ComponentHelper
{
    public class LogHelper
    {
        private RollingFileAppender _rollingFileAppender;
        private Hierarchy _hierarchy;

        /// The object to write to the log
        
        private static readonly ILog _log = LogManager.GetLogger(typeof(Logger));

       
        // Constructor requires the file log4net.config be in the bin debug folder        
        public LogHelper()
        {
            var log4NetConfig = new FileInfo("log4net.config");
            log4net.Config.XmlConfigurator.Configure(log4NetConfig);
            _hierarchy = (Hierarchy)LogManager.GetRepository();
            _rollingFileAppender = (RollingFileAppender)_hierarchy.Root.GetAppender("RollingAppender");
        }

        public void Debug(object message)
        {
            _log.Debug(message);
        }
                public void Info(object message)
        {
            _log.Info(message);
        }
               
        public void Info(object message, Exception exception)
        {
            _log.Info(message, exception);
        }
        public void Error(object message)
        {
            _log.Error(message);
        }
        public void Fatal(object message)
        {
            _log.Fatal(message);
        }
        public void Warn(object message)
        {
            _log.Warn(message);
        }
    }
}
