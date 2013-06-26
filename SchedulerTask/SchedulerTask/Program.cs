using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
using Quartz.Impl;
using log4net;

namespace SchedulerTask
{
    class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            logger.Info("Starting the Scheduler");
            var schedulerFactory = new StdSchedulerFactory(); 
            var scheduler = schedulerFactory.GetScheduler(); 
            if(!scheduler.IsStarted)
                scheduler.Start();
            logger.Info("Scheduler Started");

            var job = JobBuilder.Create<SampleJob>().Build();

            var trigger = TriggerBuilder.Create()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(15).RepeatForever())
                .Build();

            scheduler.ScheduleJob(job, trigger);
            logger.Info("Scheduler Scheduled");
        }
    }
}
