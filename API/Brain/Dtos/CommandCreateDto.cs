using System.ComponentModel.DataAnnotations;

namespace Brain.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        public int PlatformID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public string Tittle { get; set; }

        [Required]
        public string CommandText { get; set; }

        public string Description { get; set; }

        public string Note { get; set; }

        public string FileLocation { get; set; }

        [Required]
        public string MakeDate { get; set; }

        [Required]
        public string UpdateDate { get; set; }
    }
}