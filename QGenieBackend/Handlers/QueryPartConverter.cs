using AutoMapper;
using QGenieBackend.Types;

namespace QGenieBackend.Handlers
{
    public class QueryPartConverter<T> : ITypeConverter<string, T> where T : QueryPart, new()
    {
        public T Convert(string source, T destination, ResolutionContext context)
        {
            destination ??= new T();
            destination.Value = source;

            return destination;
        }
    }
}
