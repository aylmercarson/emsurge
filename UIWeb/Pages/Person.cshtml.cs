using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UIWeb.Pages;

public class PersonModel : PageModel
{
    private readonly ILogger<PersonModel> Logger;
    private readonly IInProcessPeopleRepository _iInProcessPeopleRepository;

    public PersonModel(
        ILogger<PersonModel> logger,
        IInProcessPeopleRepository iInProcessPeopleRepository)
    {
        Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _iInProcessPeopleRepository = iInProcessPeopleRepository;
    }

    public Person? Person { get; set; }

    public void OnGet(Guid id)
    {
        Person = _iInProcessPeopleRepository.GetByIdOrDefault(id) ?? throw new Exception($"Cannot find person with Id='{id}'");
    }
}
