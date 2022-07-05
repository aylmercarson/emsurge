using DateOnlyTimeOnly.AspNet.Converters;
using Domain.Interfaces.Data;
using Domain.Models.AnimalModels;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text.Json;

namespace Infrastructure;

public sealed class AnimalRepository : RepositoryBase, IRepository<Animal>
{
    private static IList<Animal> source;

    public AnimalRepository(IConfiguration configuration) : base(configuration)
    { source = new List<Animal>(); }

    public async Task<IEnumerable<Animal>> GetAllAsync()
    {
        //var source = new List<Animal>();

        string json = await File.ReadAllTextAsync(AnimalsJsonLocation);

        source = JsonSerializer.Deserialize<List<Animal>>(json, new JsonSerializerOptions
        {
            Converters = { new DateOnlyJsonConverter() }
        });

        return source.AsEnumerable();
    }

    public async Task<Animal> GetByIdOrDefault(Guid id) => source.SingleOrDefault(x => x.Id == id);
}
