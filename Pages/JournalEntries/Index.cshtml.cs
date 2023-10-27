using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Modele;

namespace MyScriptureJournal.Pages.JournalEntries
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<JournalEntry> JournalEntry { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BookNames { get; set; }
        public SelectList Dates { get; set; }
        [BindProperty(SupportsGet = true)]
        public string DateAdded { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.JournalEntry
                                            orderby m.Book
                                            select m.Book;

            IQueryable<DateTime> dateQuery = from m in _context.JournalEntry
                                             orderby m.DateAdded
                                             select m.DateAdded.Date;

            var books = from m in _context.JournalEntry
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Book.Contains(SearchString) || s.Note.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(BookNames))
            {
                books = books.Where(x => x.Book == BookNames);
            }

            if (!string.IsNullOrEmpty(DateAdded))
            {
                if (DateTime.TryParse(DateAdded, out var selectedDate))
                {
                    books = books.Where(x => x.DateAdded.Date == selectedDate.Date);
                }
            }

            Books = new SelectList(await genreQuery.Distinct().ToListAsync());
            Dates = new SelectList(await dateQuery.Distinct().ToListAsync());
            JournalEntry = await books.ToListAsync();
        }
    }
}
