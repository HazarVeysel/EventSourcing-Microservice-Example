using EventSourcing.Shared.Events;
using EventStore.ClientAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventSourcing.API.EventStores
{
    public abstract class AbstractStream
    {
        protected readonly LinkedList<IEvent> Events = new LinkedList<IEvent>();

        private string _streamName { get; }

        private readonly IEventStoreConnection _eventStoreConnection;

        protected AbstractStream(string streamName, IEventStoreConnection eventStoreConnection)
        {
            _streamName = streamName;
            _eventStoreConnection = eventStoreConnection;
        }

        //Tüm event'leri event store'a kaydetmemiz gerekiyor. Burda herbir event'i eventdata'ya dönüştürmemiz gerekiyor. Herbir x'den eventdata alıp listeye dönüştürdük
        public async Task SaveAsync()
        {
            var newEvents = Events.ToList().Select(x => new EventData(
                Guid.NewGuid(),
                x.GetType().Name,
                true,
                Encoding.UTF8.GetBytes(JsonSerializer.Serialize(x, inputType: x.GetType())),
                Encoding.UTF8.GetBytes(x.GetType().FullName))).ToList();

            //eventstoreconnection üzerinden stream'e ekledik
            await _eventStoreConnection.AppendToStreamAsync(_streamName, ExpectedVersion.Any, newEvents);

            
            Events.Clear();

        }
    }
}
