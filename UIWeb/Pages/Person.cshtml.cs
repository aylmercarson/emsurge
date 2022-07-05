using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Models.PersonModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UIWeb.Pages;

public class PersonModel : PageModel
{
    private readonly ILogger<PersonModel> _logger;
    private readonly IPersonServices _iPersonServices;

    public PersonModel(
        ILogger<PersonModel> logger,
        IPersonServices iPersonServices)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
                _logger.LogWarning(LogEvents.GetPersonNotFound, "OnGet({Id}) NOT FOUND", id);
                Error = $"Cannot find person with Id='{id}'";
            }
        }
        catch (Exception ex)
        {
            // log this
            _logger.LogError(LogEvents.GetPersonServerError, ex.Message);
            Error = $"Server error";
        }
    }
}
