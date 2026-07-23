using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
           
    }
}
