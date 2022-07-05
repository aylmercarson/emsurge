using Domain.Interfaces.Services;
using Domain.Models.PersonModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UIWeb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> Logger;
    private readonly IPersonServices _iPersonServices;

    //public IEnumerable<Person>? People { get; private set; }

    public IndexModel(
        ILogger<IndexModel> logger,
        IPersonServices iPersonServices)
    {
        Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        //_iPersonServices = iPersonServices;
    }

    public void OnGet()
    {
        //People = _iPersonServices.GetAll();
    }
}
