using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AIServices.Infrastructure
{
    public interface IRequestHandler<TRequest, TResult> // where TRequest: IRequest<TResult>
    {
        //IRequestHandler<TRequest, TResult> new(EndpointDefinition definition, Func<TRequest, TResult> requestAction);
        Task<TResult> HandleRequestAsync();

        Task<TResult> HandleRequestAsync(TRequest request);
        Task<TResult> HandleRequestAsync(TRequest request, CancellationToken cancellationToken);
        TResult HandleRequest(TRequest request);
    }
    public interface IRequest<TResult>
    {

    }
}
