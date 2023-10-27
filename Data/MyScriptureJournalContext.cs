using Microsoft.EntityFrameworkCore;

namespace MyScriptureJournal.Data
{
    public class MyScriptureJournalContext : DbContext
    {
        public MyScriptureJournalContext (DbContextOptions<MyScriptureJournalContext> options)
            : base(options)
        {
        }

        public DbSet<MyScriptureJournal.Modele.JournalEntry> JournalEntry { get; set; } = default!;
    }
}
