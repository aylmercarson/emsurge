using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UIWeb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> Logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        Logger = logger;
        People = new InProcessPeopleRepository().GetAll();
    }

    public IEnumerable<Person> People { get; private set; }

    public void OnGet()
    {

    }
}
