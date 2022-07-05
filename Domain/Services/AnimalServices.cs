using Domain.Interfaces.Data;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Models.AnimalModels;
using Microsoft.Extensions.Caching.Memory;

namespace Domain.Services;
public class AnimalServices : IServices<Animal>
{
    private readonly IRepository<Animal> _iRepository;
    private readonly IMemoryCache _memoryCache;

    public AnimalServices(IMemoryCache memoryCache, IRepository<Animal> iRepository)
    {
        _memoryCache = memoryCache;
        _iRepository = iRepository;
    }

    //TODO: these should/could be cached
    public async Task<IEnumerable<Animal>> GetAllAsync()
    {
        IEnumerable<Animal> animals = new List<Animal>();
        
        if (!_memoryCache.TryGetValue(CacheKeys.Animals, out animals))
        {
            animals = await _iRepository.GetAllAsync();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(30));

            _memoryCache.Set(CacheKeys.Animals, animals, cacheEntryOptions);
        }

        return animals;
    }

    //TODO: retrieve from cache
    public async Task<Animal> GetByIdOrDefault(Guid id)// => await _iRepository.GetByIdOrDefault(id);
    {
        IEnumerable<Animal> animals = new List<Animal>();

        if (_memoryCache.TryGetValue(CacheKeys.Animals, out animals))
        {
            return animals.FirstOrDefault(x => x.Id == id);
        }
        else
        {
            animals = await _iRepository.GetAllAsync();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(30));

            _memoryCache.Set(CacheKeys.Animals, animals, cacheEntryOptions);

            return animals.FirstOrDefault(x => x.Id == id);
        }
    }
}
