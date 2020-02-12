using System.ComponentModel.DataAnnotations;

namespace Pancake.Models
{
    public class WordsTableModel
    {
        [Key] 
        public int Id { get; set; }
        public string Word { get; set; }
        public string PartOfSpeech { get; set; }
    }
}