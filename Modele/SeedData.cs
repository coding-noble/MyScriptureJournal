using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Modele;

namespace MyScriptureJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any Journal Entries.
                if (context.JournalEntry.Any())
                {
                    return;
                }

                context.JournalEntry.AddRange(
                    new JournalEntry
                    {
                        Book = "Moroni",
                        Chapter = "10",
                        Verse = "32-33",
                        DateAdded = DateTime.Parse("2011-4-3"),
                        Note = "My Favorite"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}