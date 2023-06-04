using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using zadanie8.Interfaces;
using zadanie8.ViewModels.Person;

namespace zadanie8.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPersonService _personService;
        public ListPersonForListVM Records { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public void OnGet()
        {
            Records = _personService.GetActivePeopleForList();
        }
    }
}