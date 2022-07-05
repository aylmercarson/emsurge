using DateOnlyTimeOnly.AspNet.Converters;
using Domain.Interfaces.Data;
using Domain.Models.AnimalModels;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Infrastructure;

public class AnimalRepository : RepositoryBase, IRepository<Animal>
{
    public AnimalRepository(IConfiguration configuration) : base(configuration)
    { }

    public async Task<IEnumerable<Animal>> GetAllAsync()
    {
        var source = new List<Animal>();

        string json = await File.ReadAllTextAsync(AnimalsJsonLocation);

        source = JsonSerializer.Deserialize<List<Animal>>(json, new JsonSerializerOptions
        {
            Converters = { new DateOnlyJsonConverter() }
        });

        return source.AsEnumerable();
    }

    public async Task<Animal>? GetByIdOrDefault(Guid id) => throw new NotImplementedException();
}
