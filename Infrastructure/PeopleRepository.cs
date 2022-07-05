using DateOnlyTimeOnly.AspNet.Converters;
using Domain.Interfaces.Data;
using Domain.Models.PersonModels;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace Infrastructure;
public  class PeopleRepository : RepositoryBase, IRepository<Person>
{
    public PeopleRepository(IConfiguration configuration) : base(configuration)
    { }

    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        var source = new List<Person>();

        string peopleJson = await File.ReadAllTextAsync(PersonJsonLocation);

        source = JsonSerializer.Deserialize<List<Person>>(peopleJson, new JsonSerializerOptions
        {
            Converters = { new DateOnlyJsonConverter() }
        });

        return source.AsEnumerable();
    }
}
