using System.Security.Cryptography;

namespace ERegistration.ViewComponents
{
    public class SelectPropertyOwnerViewComponent : ViewComponent
    {
        private readonly IPropertyOwnerRepository _propertyOwnerRepository;
        private readonly ILogger<PropertyOwnerController> _logger;

        public SelectPropertyOwnerViewComponent(IPropertyOwnerRepository propertyOwnerRepository, ILogger<PropertyOwnerController> logger)
        {
            _logger = logger;
            _propertyOwnerRepository = propertyOwnerRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var propertyOwners = await _propertyOwnerRepository.GetAllPropertyOwnersAsync();
                IEnumerable<SelectListItem> selectPropertyOwners = new SelectList(propertyOwners, "Id", "Name");

                PropertyOwnerAddViewModel propertyOwnerAddViewModel = new() { propertyOwners = selectPropertyOwners};
                return View(propertyOwnerAddViewModel);
            }
            catch(Exception ex)
            {
                ViewData["ErrorMessage"] = $"There was an error: {ex.Message}";
            }
            return View(new PropertyOwnerAddViewModel());
        }
    }
}