using Domain;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UIWeb.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> Logger;
    private readonly IInProcessPeopleRepository _iInProcessPeopleRepository;

    public IEnumerable<Person>? People { get; private set; }

    public IndexModel(
        ILogger<IndexModel> logger,
        IInProcessPeopleRepository iInProcessPeopleRepository)
    {
        Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _iInProcessPeopleRepository = iInProcessPeopleRepository;
    }

    public void OnGet()
    {
        People = _iInProcessPeopleRepository.GetAll();
    }
}
