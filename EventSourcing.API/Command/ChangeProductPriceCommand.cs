using EventSourcing.API.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcing.API.Command
{
    public class ChangeProductPriceCommand:IRequest
    {
        public ChangeProductPriceDto ChangeProductPriceDto { get; set; }
    }
}
