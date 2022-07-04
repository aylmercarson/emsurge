using Domain.Interfaces.Services;
using Domain.Models;
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
    public string Error { get; set; }

    public void OnGet(Guid id)
    {
        try
        {
            Person = _iPersonServices.GetByIdOrDefault(id);

            if (null == Person)
            {
                Error = $"Cannot find person with Id='{id}'";
            }
        }
        catch (Exception ex)
        {
            // log this
            Error = $"Server error";
        }
    }
}
