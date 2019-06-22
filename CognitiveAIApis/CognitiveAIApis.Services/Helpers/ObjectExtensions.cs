using System;
using System.Collections.Generic;
using System.Text;

namespace CognitiveAIApis.Services.Helpers
{
    public static class ObjectExtensions
    {
        public static TResult PipeTo<TSource, TResult>(this TSource source, 
            Func<TSource, TResult> destination) => destination.Invoke(source);
    }
}
