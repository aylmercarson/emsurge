using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Models.AnimalModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UIWeb.Pages
{
    public class AnimalModel : PageModel
    {
        private readonly ILogger<AnimalModel> _logger;
        private readonly IServices<Animal> _iAnimalServices;

        public Animal? Animal { get; set; }
        public string Error { get; set; }

        public AnimalModel(
                            ILogger<AnimalModel> logger,
                            IServices<Animal> iAnimalServices)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _iAnimalServices = iAnimalServices;
        }

        public async Task OnGet(Guid id)
        {
            try
            {
                Animal = await _iAnimalServices.GetByIdOrDefault(id);

                if (null == Animal)
                {
                    _logger.LogWarning(LogEvents.GetAnimalNotFound, "OnGet({Id}) NOT FOUND", id);
                    Error = $"Cannot find animal with Id='{id}'";
                }
            }
            catch (Exception ex)
            {
                // log this
                _logger.LogError(LogEvents.GetAnimalServerError, ex.Message);
                Error = $"Server error";
            }
        }
    }
}
