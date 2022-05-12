using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UIWeb.Pages;

public class PersonModel : PageModel
{
    private readonly ILogger<PersonModel> Logger;

    public PersonModel(ILogger<PersonModel> logger)
    {
        Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public Person? Person { get; set; }

    public void OnGet(Guid id)
    {
        Person = new InProcessPeopleRepository().GetByIdOrDefault(id) ?? throw new Exception($"Cannot find person with Id='{id}'");
    }
}
