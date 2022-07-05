﻿using Domain.Interfaces.Data;
using Domain.Interfaces.Services;
using Domain.Models.AnimalModels;

namespace Domain.Services;
public class AnimalServices : IServices<Animal>
{
    private readonly IRepository<Animal> _iRepository;

    public AnimalServices(IRepository<Animal> iRepository)
    {
        _iRepository = iRepository;
    }

    public async Task<IEnumerable<Animal>> GetAllAsync() => await _iRepository.GetAllAsync();

    public async Task<Animal>? GetByIdOrDefault(Guid id) => await _iRepository.GetByIdOrDefault(id);
}
