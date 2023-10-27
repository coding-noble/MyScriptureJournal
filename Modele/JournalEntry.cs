using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Modele
{
    public class JournalEntry
    {
        public int ID { get; set; }
        public string Book { get; set; }

        public string Chapter { get; set; }
        [Display(Name = "Verses")]
        public String Verse { get; set; }
        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        public string Note { get; set; }
    }
}
