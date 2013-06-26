using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
using System.Net;
using log4net;

namespace SchedulerTask
{
    public class SampleJob : IJob
    {
        private EloquaService.EloquaServiceClient serviceProxy;

        private EloquaExternalActionService.ExternalActionServiceClient programServiceProxy;

        private DateTime dttLastEloquaAPICall;

        private static readonly ILog logger = LogManager.GetLogger(typeof(SampleJob));

        public void Execute(IJobExecutionContext context)
        {
            logger.Debug("Scheduler Executed : " + DateTimeOffset.Now);
            //Console.WriteLine(DateTimeOffset.Now); 
        }
    }
}
