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

        string peopleJson = await File.ReadAllTextAsync(AnimalsJsonLocation);

        source = JsonSerializer.Deserialize<List<Animal>>(peopleJson, new JsonSerializerOptions
        {
            Converters = { new DateOnlyJsonConverter() }
        });

        return source.AsEnumerable();
    }

    //Task<IEnumerable<Animal>> IRepository<Animal>.GetAllAsync() => throw new NotImplementedException();
}
