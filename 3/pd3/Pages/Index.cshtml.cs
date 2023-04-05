using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pd3.Extra;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace pd3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public Person Osoba { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Osoba?.Check();
                HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(Osoba));
                //return RedirectToPage("./Zapisane");
            }
            return Page();
        }
    }
}