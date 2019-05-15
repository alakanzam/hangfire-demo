using System;
using Hangfire;

namespace HangfireConsole.Services.Implementations
{
    public class HangfireJobActivator : JobActivator
    {
        private IServiceProvider _serviceProvider;

        public HangfireJobActivator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override object ActivateJob(Type type)
        {
            return _serviceProvider.GetService(type);
        }
    }
}