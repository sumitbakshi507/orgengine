using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OrgLive.Domain.Core.Bus;
using OrgLive.Infra.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrgLive.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, OrgLiveBg>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new OrgLiveBg(sp.GetService<IMediator>(), scopeFactory);
            });

            //Subscriptions

            //Domain Events

            //Domain Commands

            //Application Services

            //Data
        }
    }
}
