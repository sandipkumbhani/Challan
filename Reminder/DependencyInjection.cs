using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Util;

namespace Reminder
{
    [DisallowConcurrentExecution]
    public static class DependencyInjection
    {
        public static void AddQuartzExtensions(this IServiceCollection service)
        {
            service.AddQuartz(option =>
            {
                var jobKey = JobKey.Create(nameof(EmailBackGroundJob));

                var result = option.AddJob<EmailBackGroundJob>(jobBuilder => jobBuilder.WithIdentity(jobKey))
                .AddTrigger(x => x.ForJob(jobKey)
                .WithSimpleSchedule(x => x.WithIntervalInHours(24)
                .RepeatForever()));
            });
            service.AddQuartzHostedService(opt =>
            {
                opt.WaitForJobsToComplete = true;
            });
        }
    }
}
