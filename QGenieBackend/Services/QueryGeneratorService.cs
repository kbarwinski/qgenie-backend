using QGenieBackend.Types;

namespace QGenieBackend.Services
{
    public class QueryGeneratorService : IQueryGeneratorService
    {
        public string GenerateQueryFromPOCO<T>(T poco) where T : class
        {
            Type actualType = poco.GetType();

            var queryParts = actualType.GetProperties()
                .Where(p => typeof(QueryPart).IsAssignableFrom(p.PropertyType) || p.PropertyType.IsSubclassOf(typeof(QueryPart)))
                .Select(p => p.GetValue(poco) as QueryPart)
                .Where(qp => qp != null)
                .ToList();

            return GenerateQuery(queryParts);
        }

        private string GenerateQuery(List<QueryPart> queryParts)
        {
            var orderedParts = queryParts.OrderBy(q => q.Precedence).ToList();
            var query = string.Join("\n", orderedParts.Select(q => q.GetQuery()));

            return query;
        }
    }
}
