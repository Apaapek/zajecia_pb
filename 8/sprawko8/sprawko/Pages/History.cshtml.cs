using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using sprawko.Interfaces;
using sprawko.Models.Entities;
using sprawko.ViewModels.History;

namespace sprawko.Pages
{
    public class HistoryModel : PageModel
    {
        private readonly IHistoryService _historyService;
        private readonly UserManager<User> _userManager;

        [BindProperty]
        [Required]
        public int DeleteEntryId { get; set; }

        public ListHistoryForListVM LeapYearChecks { get; set; }
        public int? currentUserId { get; private set; }

        public HistoryModel(IHistoryService historyService, UserManager<User> userManager)
        {
            _historyService = historyService;
            _userManager = userManager;
        }

        public void OnGet(int? pageIndex)
        {
            currentUserId = int.TryParse(_userManager.GetUserId(User), out var temp) ? temp : null;

            LeapYearChecks = _historyService.GetHistory(pageIndex ?? 1);
        }

        public IActionResult OnPost(int? pageIndex)
        {
            currentUserId = int.TryParse(_userManager.GetUserId(User), out var temp) ? temp : null;

            LeapYearChecks = _historyService.GetHistory(pageIndex ?? 1);

            if (!ModelState.IsValid || currentUserId == null)
                return Page();

            _historyService.DeleteEvent(DeleteEntryId, (int)currentUserId);

            return Page();
        }
    }
}
 