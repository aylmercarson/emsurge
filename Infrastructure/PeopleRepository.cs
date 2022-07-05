using DateOnlyTimeOnly.AspNet.Converters;
using Domain.Interfaces.Data;
using Domain.Models.PersonModels;
using System.Text.Json;

namespace Infrastructure;
public  class PeopleRepository : IPeopleRepository
{
    public async Task<IEnumerable<Person>> GetPeopleAsync()
    {
        var source = new List<Person>();

        string peopleJson = await File.ReadAllTextAsync(@"E:\Source\home-coding-exercise-2022\Infrastructure\people.json");
        source = JsonSerializer.Deserialize<List<Person>>(peopleJson, new JsonSerializerOptions
        {
            Converters = { new DateOnlyJsonConverter() }
        });

        return source.AsEnumerable();
    }
}
