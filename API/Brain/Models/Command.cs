using System.ComponentModel.DataAnnotations;
namespace Brain.Models
{
    public class Command
    {
        [Key]
        public int CommandID { get; set; }
        public int PlatformID { get; set; }
        public int CategoryID { get; set; }
        public Platform Platform { get; set; }
        public Category Category { get; set; }
        public string Tittle { get; set; }
        public string CommandText { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string FileLocation { get; set; }
        public string MakeDate { get; set; }
        public string UpdateDate { get; set; }
    }
}