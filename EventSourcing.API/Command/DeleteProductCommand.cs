using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcing.API.Command
{
    public class DeleteProductCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
