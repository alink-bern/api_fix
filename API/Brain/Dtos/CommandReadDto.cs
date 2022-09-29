using System.ComponentModel.DataAnnotations;

namespace Brain.Dtos
{
    public class CommandReadDto
    {
        public int id { get; set; }

        public int PlatformID { get; set; }
        public int CategoryID { get; set; }
        public string Tittle { get; set; }
        public string CommandText { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public string MakeDate { get; set; }
        public string UpdateDate { get; set; }
    }
}