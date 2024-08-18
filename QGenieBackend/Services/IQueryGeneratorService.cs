namespace QGenieBackend.Services
{
    public interface IQueryGeneratorService
    {
        string GenerateQueryFromPOCO<T>(T poco) where T : class;
    }
}
