using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Modele;

namespace MyScriptureJournal.Pages.JournalEntries
{
    public class DetailsModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public DetailsModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

      public JournalEntry JournalEntry { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.JournalEntry == null)
            {
                return NotFound();
            }

            var journalentry = await _context.JournalEntry.FirstOrDefaultAsync(m => m.ID == id);
            if (journalentry == null)
            {
                return NotFound();
            }
            else 
            {
                JournalEntry = journalentry;
            }
            return Page();
        }
    }
}
