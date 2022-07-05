using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Models.PersonModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UIWeb.Pages;

public class PersonModel : PageModel
{
    private readonly ILogger<PersonModel> _logger;
    private readonly IServices<Person> _iPersonServices;

    public PersonModel(
        ILogger<PersonModel> logger,
         IServices<Person> iPersonServices)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _iPersonServices = iPersonServices;
    }

    public Person? Person { get; set; }
    public string Error { get; set; }

    public async Task OnGet(Guid id)
    {
        try
        {
            Person = await _iPersonServices.GetByIdOrDefault(id);

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
