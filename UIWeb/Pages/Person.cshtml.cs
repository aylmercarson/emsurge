using Domain;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UIWeb.Pages;

public class PersonModel : PageModel
{
    private readonly ILogger<PersonModel> Logger;
    private readonly IPersonServices _iPersonServices;

    public PersonModel(
        ILogger<PersonModel> logger,
        IPersonServices iPersonServices)
    {
        Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _iPersonServices = iPersonServices;
    }

    public Person? Person { get; set; }

    public void OnGet(Guid id)
    {
        Person = _iPersonServices.GetByIdOrDefault(id) ?? throw new Exception($"Cannot find person with Id='{id}'");
    }
}
