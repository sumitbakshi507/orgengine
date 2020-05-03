using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OrgLive.Domain.Core.Bus;
using OrgLive.Infra.Bus;
using OrgLive.QuotingEngine.Application.Interfaces;
using OrgLive.QuotingEngine.Application.Services;
using OrgLive.QuotingEngine.Data.Context;
using OrgLive.QuotingEngine.Data.Repository;
using OrgLive.QuotingEngine.Domain.EventHandlers;
using OrgLive.QuotingEngine.Domain.Events;
using OrgLive.QuotingEngine.Domain.Interfaces;

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
            services.AddTransient<IEventHandler<QuoteRequestCreatedEvent>, QuoteRequestEventHandler>();

            //Domain Commands

            //Application Services
            services.AddTransient<IQuoteService, QuoteService>();

            //Data
            services.AddTransient<IQuoteRepository, QuoteRepository>();
            services.AddTransient<QuoteDbContext>();
        }
    }
}
