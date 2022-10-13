using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Product oluşması için gerekli olan propertyler
namespace EventSourcing.Shared.Events
{
    public class ProductCreatedEvent:IEvent
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int UserID { get; set; }
    }
}
