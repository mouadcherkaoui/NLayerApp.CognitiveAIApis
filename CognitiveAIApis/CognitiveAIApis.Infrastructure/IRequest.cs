using System;
using System.Collections.Generic;
using System.Text;

namespace CognitiveAIApis.Infrastructure
{
    public interface IRequest<TRequest>
    {
        TRequest RequestObject { get; }
    }
}
