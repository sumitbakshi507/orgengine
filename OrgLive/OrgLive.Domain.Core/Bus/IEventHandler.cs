using System.Threading.Tasks;
using OrgLive.Domain.Core.Events;

namespace OrgLive.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
