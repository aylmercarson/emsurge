using Domain.Interfaces.Services;
using Domain.Models.PersonModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UIWeb.Pages
{
    public class PeopleModel : PageModel
    {
        private readonly ILogger<IndexModel> Logger;
        private readonly IPersonServices _iPersonServices;

        public IEnumerable<Person>? People { get; private set; }

        public PeopleModel(
            ILogger<IndexModel> logger,
            IPersonServices iPersonServices)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _iPersonServices = iPersonServices;
        }

        public async Task OnGet()
        {
            People = await _iPersonServices.GetAllAsync();
        }
    }
}
