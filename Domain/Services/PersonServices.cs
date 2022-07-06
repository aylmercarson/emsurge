using Domain.Interfaces.Data;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Models.PersonModels;
using Microsoft.Extensions.Caching.Memory;

namespace Domain.Services;
public class PersonServices: IServices<Person>
{
    private readonly IRepository<Person> _iRepository;
    private readonly IMemoryCache _memoryCache;

    public PersonServices(IMemoryCache memoryCache, IRepository<Person> iPeopleRepository)
    {
        _memoryCache = memoryCache;
        _iRepository = iPeopleRepository;
    }

    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        IEnumerable<Person> people = new List<Person>();

        if (!_memoryCache.TryGetValue(CacheKeys.People, out people))
        {
            people = await _iRepository.GetAllAsync();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(30));

            _memoryCache.Set(CacheKeys.People, people, cacheEntryOptions);
        }

        return people;
    }

    // retrieve from cache
    public async Task<Person> GetByIdOrDefault(Guid id)
    {
        IEnumerable<Person> people = new List<Person>();

        if (_memoryCache.TryGetValue(CacheKeys.People, out people))
        {
            return people.FirstOrDefault(x => x.Id == id);
        }

        people = await _iRepository.GetAllAsync();

        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(30));

        _memoryCache.Set(CacheKeys.People, people, cacheEntryOptions);

        return people.FirstOrDefault(x => x.Id == id);
    }
}
