using DateOnlyTimeOnly.AspNet.Converters;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Infrastructure;
public abstract class Repository : RepositoryBase
{
    public Repository(IConfiguration configuration) : base(configuration)
    { }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var source = new List<T>();

        string json = await File.ReadAllTextAsync(PersonJsonLocation);

        source = JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions
        {
            Converters = { new DateOnlyJsonConverter() }
        });

        return source.AsEnumerable();
    }
}
