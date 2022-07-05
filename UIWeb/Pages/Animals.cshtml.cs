using Domain.Interfaces.Services;
using Domain.Models.AnimalModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UIWeb.Pages
{
    public class AnimalsModel : PageModel
    {
        private readonly ILogger<IndexModel> Logger;
        private readonly IServices<Animal> _iAnimalServices;

        public IEnumerable<Animal>? Animals { get; private set; }

        public AnimalsModel(
            ILogger<IndexModel> logger,
            IServices<Animal> iAnimalServices)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _iAnimalServices = iAnimalServices;
        }

        public async Task OnGet()
        {
            Animals = await _iAnimalServices.GetAllAsync();
        }
    }
}
